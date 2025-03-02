using ModelRepo;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using ServiceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeCRUD2.Controllers
{
    public class ReportController : Controller
    {
        private readonly IEmployeeService _Iemp;

        public ReportController(IEmployeeService Iemp)
        {
            _Iemp = Iemp;
        }
        public FileContentResult ExportToExcel()
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial; 

            List<Employee> employees = _Iemp.GetAllEmp().ToList(); 

            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Employees");

                worksheet.Cells[1, 1].Value = "Name";
                worksheet.Cells[1, 2].Value = "Email";
                worksheet.Cells[1, 3].Value = "Phone";
                worksheet.Cells[1, 4].Value = "Salary";

                var headerCells = worksheet.Cells["A1:D1"];
                headerCells.Style.Font.Bold = true;
                headerCells.Style.Font.Color.SetColor(System.Drawing.Color.White);
                headerCells.Style.Fill.PatternType = ExcelFillStyle.Solid;
                headerCells.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.DarkBlue);
                headerCells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                int row = 2; 
                foreach (var emp in employees)
                {
                    worksheet.Cells[row, 1].Value = emp.Fname+" "+emp.Lname;
                    worksheet.Cells[row, 2].Value = emp.Email;
                    worksheet.Cells[row, 3].Value = emp.Phone;
                    worksheet.Cells[row, 4].Value = emp.Salary;
                    row++;
                }

                worksheet.Cells[$"D2:D{row-1}"].Style.Numberformat.Format = "#,##0.00";

                worksheet.Cells.AutoFitColumns(); 

                byte[] fileContents = package.GetAsByteArray();
                return File(fileContents, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Employees.xlsx");
            }
        }
    }
}


