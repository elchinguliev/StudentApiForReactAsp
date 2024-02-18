using System.ComponentModel.DataAnnotations;

namespace ApiForReactAsp.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
    }
}
