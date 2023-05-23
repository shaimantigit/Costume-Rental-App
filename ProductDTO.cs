using System.ComponentModel.DataAnnotations;

namespace FinalMockProject.Models.DTO
{
    public class ProductDTO
    {
        [Required]
        public string Product_Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Security_Deposit { get; set; }
        [Required]
        public double Rental_Price { get; set; }
        [Required]
        public int Product_Id { get; set; }
       
    }
}
