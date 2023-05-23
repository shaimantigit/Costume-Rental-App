using System.ComponentModel.DataAnnotations;

namespace FinalMockProject.Models.Authentication
{
    public class AuthUserLogin
    {
    
        
            [Required]
            [StringLength(100, MinimumLength = 3)]
            public string User_email { get; set; } = null!;

            [Required]
           // [StringLength(100)]
            public string User_Password { get; set; } = null;
        
    }
}
