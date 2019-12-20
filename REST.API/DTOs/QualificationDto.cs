using System;
using System.ComponentModel.DataAnnotations;

namespace REST.API.DTOs
{
    public class QualificationDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Type { get; set; }
        public double Grade { get; set; }
        [Required]
        public DateTime? Date { get; set; }
        public int StaffId { get; set; }
    }
}