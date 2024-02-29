using ready.labs.Models;

namespace ready.labs.Services
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees();

    }
}
