using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFirstAPI.Domain.Model
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        public int id { get; set; }

        public string nome { get; set; }

        public int age { get; set; }

        public string? photo { get; set; }

        public Employee(string nome, int age, string photo)
        {
            this.nome = nome ?? throw new ArgumentNullException(nameof(nome));
            this.age = age;
            this.photo = photo;
        }

        public Employee()
        {
        }
    }
}
