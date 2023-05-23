using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalMockProject.Models
{
    public class User
    {
        [Key]
        public int User_Id { get; set; }
        [Required]
        public string User_Name { get; set; }
        //[MaxLength(100,ErrorMessage ="Password shoild have maximum  10 characters.")]
        [Required]
        public string User_Password { get; set; }
       
       // [MaxLength(10, ErrorMessage = "Contact Number must be of 10 digits.")]
        public int User_Contact { get; set; }
      

        public string User_Email { get; set; }
       
        public string Home_Address { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public  Role Roles { get; set; }
        public ICollection<Order> Orders { get; set; }

       

    }
}
