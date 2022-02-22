using System;

namespace ProjectExample.Domain
{
    public class EmployeeDomain
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string RoleJob { get; set; }
    }
}