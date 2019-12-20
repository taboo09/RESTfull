using System;

namespace REST.Domain.Entities
{
    public class Qualification
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Grade { get; set; }
        public DateTime Date { get; set; }
        public int StaffId { get; set; }
        public Staff Staff { get; set; }
    }
}