using DataLinkRepo;
using ModelRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceRepo
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmpRepo _emprepo;

        public EmployeeService(IEmpRepo emprepo)
        {
            _emprepo = emprepo;
        }

        public List<Employee> GetAllEmp()
        {
            return _emprepo.GetAllEmpData()
                  .Select(e =>
                  {
                      e.Salary = e.Salary * 1.012m; 
                      return e;
                  })
                  .ToList();
        }

    }
}
