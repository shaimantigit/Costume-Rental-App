using System.ComponentModel.DataAnnotations;

namespace FinalMockProject.Models.DTO
{
    public class AddUserDTO
    {
        public int User_Id { get; set; }
        [Required]
        public string User_Name { get; set; }
        [Required]
       // [MaxLength(100, ErrorMessage = "Password shoild have maximum  10 characters.")]
        public string User_Password { get; set; }
        [Required]
        //[MaxLength(10, ErrorMessage = "Contact Number must be of 10 digits.")]
        public int User_Contact { get; set; }
        [Required]

        public string User_Email { get; set; }
        [Required]
        public string Home_Address { get; set; }
        [Required]
        public int RoleId { get; set; }
    }
}
