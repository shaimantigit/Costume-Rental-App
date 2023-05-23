using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalMockProject.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetail_Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        
        [ForeignKey("Order")]
        public int Order_Id { get; set; }
        public Order Order { get; set; }

        [ForeignKey("Prodcut")]
        public int Product_Id { get; set; }
        public Product Product { get; set; }


    }
}
