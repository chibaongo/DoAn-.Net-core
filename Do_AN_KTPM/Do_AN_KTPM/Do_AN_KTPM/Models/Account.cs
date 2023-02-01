using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.PortableExecutable;

namespace Do_AN_KTPM.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string  Password { get; set; }


        public string Email { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string Fullname { get; set; }
        public bool IsAdmin { get; set; }
        public string Avatar { get; set; }
        [NotMapped]
        public IFormFile AvatarFile { get; set; }
        public bool Status { get; set; }
        public Invoice Invoice { get; set; }
    }
}
