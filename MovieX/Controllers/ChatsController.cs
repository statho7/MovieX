﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieX.Models;

namespace MovieX.Controllers
{
    public class ChatsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Chats
        public ActionResult Index()
        {
            var chats = db.Chats.Include(c => c.Receiver).Include(c => c.Sender);
            return View(chats.ToList());
        }

        // GET: Chats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chat chat = db.Chats.Find(id);
            if (chat == null)
            {
                return HttpNotFound();
            }
            return View(chat);
        }

        // GET: Chats/Create
        public ActionResult Create()
        {
            ViewBag.ReceiverId = new SelectList(db.ApplicationUsers, "Id", "FirstName");
            ViewBag.SenderId = new SelectList(db.ApplicationUsers, "Id", "FirstName");
            return View();
        }

        // POST: Chats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SenderId,ReceiverId,SentTime,Subject,Message")] Chat chat)
        {
            if (ModelState.IsValid)
            {
                db.Chats.Add(chat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReceiverId = new SelectList(db.ApplicationUsers, "Id", "FirstName", chat.ReceiverId);
            ViewBag.SenderId = new SelectList(db.ApplicationUsers, "Id", "FirstName", chat.SenderId);
            return View(chat);
        }

        //// GET: Chats/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Chat chat = db.Chats.Find(id);
        //    if (chat == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ReceiverId = new SelectList(db.ApplicationUsers, "Id", "FirstName", chat.ReceiverId);
        //    ViewBag.SenderId = new SelectList(db.ApplicationUsers, "Id", "FirstName", chat.SenderId);
        //    return View(chat);
        //}

        //// POST: Chats/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,SenderId,ReceiverId,SentTime,Subject,Message")] Chat chat)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(chat).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ReceiverId = new SelectList(db.ApplicationUsers, "Id", "FirstName", chat.ReceiverId);
        //    ViewBag.SenderId = new SelectList(db.ApplicationUsers, "Id", "FirstName", chat.SenderId);
        //    return View(chat);
        //}

        // GET: Chats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chat chat = db.Chats.Find(id);
            if (chat == null)
            {
                return HttpNotFound();
            }
            return View(chat);
        }

        // POST: Chats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chat chat = db.Chats.Find(id);
            db.Chats.Remove(chat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
