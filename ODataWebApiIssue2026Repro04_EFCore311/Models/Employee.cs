using System.ComponentModel.DataAnnotations;

namespace ODataWebApiIssue2026Repro04_EFCore311.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int EmployerId { get; set; }
        public virtual Employer Employer { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
