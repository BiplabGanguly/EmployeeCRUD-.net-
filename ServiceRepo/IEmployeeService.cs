using ModelRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceRepo
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmp();
    }
}
