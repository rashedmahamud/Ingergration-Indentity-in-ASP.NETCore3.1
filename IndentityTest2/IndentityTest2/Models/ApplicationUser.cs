using Microsoft.AspNetCore.Identity;
using System;

namespace IndentiyTest2.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Rating { get; set; }
        public string ProfileImageUrl { get; set; }
        public DateTime MemberSince { get; set; }
    }
}