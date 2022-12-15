namespace lab3.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int ID_Office { get; set; }
        public long Phone { get; set; }
        public int? position_id { get; set; }
        public Position? Position { get; set; }
    }

}
}