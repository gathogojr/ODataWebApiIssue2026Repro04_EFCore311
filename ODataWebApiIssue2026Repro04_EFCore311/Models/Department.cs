using System.ComponentModel.DataAnnotations;

namespace ODataWebApiIssue2026Repro04_EFCore311.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
