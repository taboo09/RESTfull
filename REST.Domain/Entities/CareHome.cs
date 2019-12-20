using System.Collections.Generic;

namespace REST.Domain.Entities
{
    public class CareHome
    {
        public CareHome()
        {
            Staffs = new HashSet<Staff>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Rating { get; set; }
        public ICollection<Staff> Staffs { get; set; }
    }
}