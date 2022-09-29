using System.ComponentModel.DataAnnotations;

namespace AuthAothIdentityManager.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
