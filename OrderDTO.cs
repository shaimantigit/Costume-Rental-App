namespace FinalMockProject.Models.DTO
{
    public class OrderDTO
    {
        public int Order_Id { get; set; }
        public double TotalAmount { get; set; }
        public DateTime DateOfRent { get; set; }
        public DateTime Return_Date { get; set; }
        public Boolean Is_Returned { get; set; }
        public int User_Id { get; set; }

    }
}
