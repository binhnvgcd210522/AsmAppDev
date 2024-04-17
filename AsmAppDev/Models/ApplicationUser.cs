using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AsmAppDev.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public bool Status { get; set; }
    }
}
