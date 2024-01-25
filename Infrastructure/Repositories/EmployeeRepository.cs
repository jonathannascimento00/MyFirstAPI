using MyFirstAPI.Domain.Model;

namespace MyFirstAPI.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public void Add(Employee employee) { 
            _context.Employess.Add(employee);
            _context.SaveChanges();
        }

        public List<Employee> Get(int pageNumber, int pageQuantity) {
            return _context.Employess.Skip(pageNumber * pageQuantity).Take(pageQuantity).ToList();
        }

        public Employee? GetEmployeeById(int id)
        {
            return _context.Employess.Find(id);
        }
    }
}
