using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AuthAothIdentityManager.Models.Model
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }
    }
}
