using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MovieX.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace MovieX.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(255)]
        public string Password { get; set; }



        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d/M/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        [Required]
        public Country Country { get; set; }

        [Required]
        public Gender Gender { get; set; }

        //[Required]
        //public Genre FirstChoice { get; set; }

        //[Required]
        //public Genre SecondChoice { get; set; }

        //[Required]
        //public Genre ThirdChoice { get; set; }

        //isws me tin dimiourgia na xreiazetai na tou ftiaxnoume kai tin lista pou tha prosthetei tainies.
        public List<Movie> MoviesList = new List<Movie>();
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        // We save the time the user paid the subscription
        public DateTime? SubDate { get; set; }

        // We save if the user paid the subscription
        public int IsPaid { get; set; }
    }
}