using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FluentValidationNET5.Models
{
    [Table("students")]
    public class Student : BaseEntity
    {
        [Column("full_name")]
        public string FullName { get; set; }
        
        [Column("birth_date")]
        public DateTime BirthDate { get; set; }
        
        [Column("document")]
        public string Document { get; set; }
        
        [Column("phone_number")]
        public string PhoneNumber { get; set; }
        
        [Column("full_address")]
        public string FullAddress { get; set; }
    }
}