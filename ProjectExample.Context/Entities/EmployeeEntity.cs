using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectExample.Context.Entities
{
    public class EmployeeEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string RoleJob { get; set; }
    }
}