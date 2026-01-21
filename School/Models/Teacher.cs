using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace School.Models
{
    public class Teacher
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Qualification { get; set; }

        public string? FotoPath { get; set; }

        public string IdentityUserID { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }
    }
}
