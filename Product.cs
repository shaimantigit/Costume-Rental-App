using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalMockProject.Models
{
    public class Product
    {
        [Key]
        public int Product_Id { get; set; }
        [Required]
        public string Product_Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Security_Deposit { get; set; }
        [Required]
        public double Rental_Price { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
