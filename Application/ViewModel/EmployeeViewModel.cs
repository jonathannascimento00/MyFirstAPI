using Microsoft.AspNetCore.Http;

namespace MyFirstAPI.Application.ViewModel
{
    public class EmployeeViewModel
    {
        public string Name { get; set; }

        public int age { get; set; }

        public IFormFile Photo { get; set; }
    }
}
