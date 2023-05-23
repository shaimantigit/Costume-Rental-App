using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalMockProject.Models
{
    public class Order
    {
        [Key]
        public int Order_Id { get; set; }
        [Required]
        public double TotalAmount { get; set; }
        [Required]
        public DateTime DateOfRent { get; set; }
        [Required]
        public DateTime Return_Date { get; set; }

        public Boolean Is_Returned { get; set; }
        [ForeignKey("User")]
        public int User_Id { get; set; }
        public User User { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }










    }
}
