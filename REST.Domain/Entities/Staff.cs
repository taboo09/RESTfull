using System;
using System.Collections.Generic;

namespace REST.Domain.Entities
{
    public class Staff
    {
        public Staff()
        {
            Qualifications = new HashSet<Qualification>();
        }

        public int Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string JobTitle { get; set; }
        public decimal AnnualSalary { get; set; }
        public int HomeId { get; set; }
        public CareHome CareHome { get; set; }
        public ICollection<Qualification> Qualifications { get; set; }
    }
}