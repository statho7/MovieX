using MovieX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PayPal.Api;
using MovieX.Models.Paypal;
using System.Globalization;

namespace MovieX.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Users
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        public ActionResult Delete(string id)
        {
            var user = db.Users.Where(u => u.Id == id).FirstOrDefault();
            return View(user);
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Delete(ApplicationUser appuser)
        {
            var user = db.Users.Where(u => u.Id == appuser.Id).FirstOrDefault();
            db.Users.Remove(user);
            db.SaveChanges();
            //var user = context.Users.Where(u => u.Id == id.ToString()).FirstOrDefault();
            return RedirectToAction("Index");
        }
        [AllowAnonymous]
        public ActionResult Edit(string id)
        {
            var user = db.Users.Where(u => u.Id == id).FirstOrDefault();
            return View(user);
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Edit(ApplicationUser appuser)
        {
            var user = db.Users.Where(u => u.Id == appuser.Id).FirstOrDefault();
            //context.Entry(appuser).State = EntityState.Modified;
            user.FirstName = appuser.FirstName;
            user.LastName = appuser.LastName;
            user.Gender = appuser.Gender;
            user.FirstChoice = appuser.FirstChoice;
            user.SecondChoice = appuser.SecondChoice;
            user.ThirdChoice = appuser.ThirdChoice;
            user.Email = appuser.Email;

            db.SaveChanges();
            //var user = context.Users.Where(u => u.Id == id.ToString()).FirstOrDefault();
            return RedirectToAction("Index");
        }

        //[HttpGet]
        public ActionResult Details(string id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            var user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //Work with Paypal payment
        private Payment payment;

        //Create a payment using an APIContext
        private Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {
            var listItems = new ItemList() { items = new List<Item>() };
            //payment information
            listItems.items.Add(new Item()
            {
                name = "subscription",
                currency = "EUR",
                price = "5.00",
                quantity = "1",
                sku = "sku"
            });

            var payer = new Payer() { payment_method = "paypal" };

            //Do the cofiguration RedirectURLs here with redirectUrl object
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl + "&Cancel=true",
                return_url = redirectUrl
            };

            //Create details object
            var details = new Details()
            {
                tax = "1.00",
                shipping = "2.00",
                subtotal = "5.00"
            };

            //Create amount object
            var amount = new Amount()
            {
                currency = "EUR",
                total = (Convert.ToDecimal(details.tax,new CultureInfo("en-US")) + Convert.ToDecimal(details.shipping, new CultureInfo("en-US")) + Convert.ToDecimal(details.subtotal, new CultureInfo("en-US"))).ToString("0.00"),//tax+shipping+subtotal
                details = details
            };

            //Create transaction
            var transactionList = new List<Transaction>();
            transactionList.Add(new Transaction()
            {
                description = "MovieX transaction description",
                invoice_number = Convert.ToString((new Random()).Next(100000)),
                amount = amount,
                item_list = listItems
            });

            payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };

            return payment.Create(apiContext);
        }

        //Create Execute Payment method
        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };

            payment = new Payment() { id = paymentId };
            return payment.Execute(apiContext, paymentExecution);
        }

        //Create PaymentWithPaypal method
        public ActionResult PaymentWithPaypal()
        {
            //Get context from the paypal bases on clientId and clientSecret for payment
            APIContext apiContext = PaypalConfiguration.GetAPIContext();

            try
            {
                string payerId = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerId))
                {
                    //Creating payment
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/Users/PaymentWithPaypal?";
                    var guid = Convert.ToString((new Random()).Next(100000));
                    var createdPayment = CreatePayment(apiContext, baseURI + "guid=" + guid);

                    //Get links returned from paypal response to create call function
                    var links = createdPayment.links.GetEnumerator();
                    string paypalRedirectUrl = string.Empty;
                    while (links.MoveNext())
                    {
                        Links link = links.Current;
                        if (link.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            paypalRedirectUrl = link.href;
                        }
                    }
                    return Redirect(paypalRedirectUrl);
                }
                else
                {
                    //This one will be executed when we have received all payment params from previous call
                    var guid = Request.Params["guid"];
                    var executePayment = ExecutePayment(apiContext, payerId , guid as string /*, Session[guid] as string*/);
                    if (executePayment.state.ToLower() != "approved")
                    {
                        return View("Failure");
                    }
                }
            }
            catch (Exception ex)
            {
                //PaypalLogger.Log("Error: " + ex.Message);
                return View("Failure");
            }
            return View("Success");
        }
    }
}