using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Model;
using MyFirstAPI.ViewModel;

namespace MyFirstAPI.Controllers
{
    [ApiController]
    [Route("api/v1/employee")]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeController> _logger;

		public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger)
		{
			_employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		[Authorize]
        [HttpPost]
        public IActionResult Add([FromForm]EmployeeViewModel employeeVm)
        {
            var filePath = Path.Combine("Storage", employeeVm.Photo.FileName);
            Stream fileStream = new FileStream(filePath, FileMode.Create);

            employeeVm.Photo.CopyTo(fileStream);

            var employee = new Employee(employeeVm.Name, employeeVm.age, filePath);

            _employeeRepository.Add(employee);

            return Ok();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get(int pageNumber, int pageQuantity)
        {
            _logger.LogInformation("Entrou no método Get");

            var employess = _employeeRepository.Get(pageNumber, pageQuantity);

            return Ok(employess);
        }

        [Authorize]
        [HttpPost]
        [Route("{id}/download")]
        public IActionResult DownloadPhoto(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);

            var dataBytes = System.IO.File.ReadAllBytes(employee.photo);

            return File(dataBytes, "image/png");
        }
    }
}
