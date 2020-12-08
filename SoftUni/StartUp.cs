using System;
using System.Globalization;
using System.Linq;
using System.Text;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        private static StringBuilder _sb;

        public static void Main()
        {
            _sb = new StringBuilder();

            var context = new SoftUniContext();

            var result = GetEmployeesByFirstNameStartingWithSa(context);

            Console.WriteLine(result);
        }

        //Problem 04 for Judge
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary,
                    e.EmployeeId
                })
                .OrderBy(e => e.EmployeeId)
                .ToList();

            foreach (var employee in employees)
            {
                _sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }

            return _sb.ToString().TrimEnd();
        }

        //Problem 05 for Judge
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context
                 .Employees
                 .Where(e => e.Salary > 50000)
                 .Select(e => new
                 {
                     e.FirstName,
                     e.Salary
                 })
                 .OrderBy(e => e.FirstName)
                 .ToList();

            foreach (var employee in employees)
            {
                _sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return _sb.ToString().TrimEnd();
        }

        //Problem 06 for Judge
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary,
                    e.Department,
                    e.LastName
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            foreach (var employee in employees)
            {
                _sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Department.Name} - ${employee.Salary:f2}");
            }

            return _sb.ToString().TrimEnd();
        }

        //Problem 07 for Judge
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var employeeNakov = context.Employees.First(e => e.LastName == "Nakov");
            employeeNakov.Address = newAddress;

            context.SaveChanges();

            var addresses = context
                .Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText)
                .ToList();

            foreach (var address in addresses)
            {
                _sb.AppendLine($"{address}");
            }

            return _sb.ToString().TrimEnd();
        }

        //Problem 08 for Judge
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(e => e.EmployeesProjects
                    .Any(ep =>
                        ep.Project.StartDate.Year >= 2001 &&
                        ep.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Project = e.EmployeesProjects
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name,
                            StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt",
                                CultureInfo.InvariantCulture),
                            EndDate = ep.Project.EndDate.HasValue
                                ? ep.Project
                                    .EndDate
                                    .Value
                                    .ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                                : "not finished"
                        })
                        .ToList()
                })
                .ToList();

            foreach (var employee in employees)
            {
                _sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager {employee.ManagerFirstName} {employee.ManagerLastName}");
                foreach (var project in employee.Project)
                {
                    _sb.AppendLine($"--{project.ProjectName} - {project.StartDate} - {project.EndDate}");
                }
            }

            return _sb.ToString().TrimEnd();
        }

        //TODO Problem 09

        //Problem 10 for Judge
        public static string GetEmployee147(SoftUniContext context)
        {
            var employee147 = context
                .Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                        .Select(ep => ep.Project.Name)
                        .OrderBy(pn => pn)
                        .ToList()
                })
                .Single();

            _sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            foreach (var project in employee147.Projects)
            {
                _sb.AppendLine(project);
            }

            return _sb.ToString().TrimEnd();
        }

        //Problem 11 for Judge
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context
                .Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLasttName = d.Manager.LastName,
                    DepEmployees = d.Employees
                        .Select(e => new
                        {
                            EmployeeFirstName = e.FirstName,
                            EmployeeLastName = e.LastName,
                            e.JobTitle
                        })
                        .OrderBy(e => e.EmployeeFirstName)
                        .ThenBy(e => e.EmployeeLastName)
                        .ToList()
                })
                .ToList();

            foreach (var department in departments)
            {
                _sb.AppendLine($"{department.Name} - {department.ManagerFirstName} {department.ManagerLasttName}");

                foreach (var employee in department.DepEmployees)
                {
                    _sb.AppendLine($"{employee.EmployeeFirstName} {employee.EmployeeLastName} - {employee.JobTitle}");
                }
            }

            return _sb.ToString().TrimEnd();
        }

        //TODO Problem 12

        //Problem 13 for Judge
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var emplyeesToIncrease = context
                .Employees
                .Where(e =>
                    e.Department.Name == "Engineering" ||
                    e.Department.Name == "Tool Design" ||
                    e.Department.Name == "Marketing" ||
                    e.Department.Name == "Information Services"
                );

            foreach (var employee in emplyeesToIncrease)
            {
                employee.Salary += employee.Salary * 0.12m;
            }

            context.SaveChanges();

            var employeesInfo = emplyeesToIncrease
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary
                })
                .OrderBy(e=>e.FirstName)
                .ThenBy(e=>e.FirstName)
                .ToList();

            foreach (var employee in employeesInfo)
            {
                _sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            return _sb.ToString().TrimEnd();
        }

        //Poblem 14 for Judge
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e=>e.FirstName)
                .ThenBy(e=>e.LastName)
                .ToList();

            foreach (var e in employees)
            {
                _sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }

            return _sb.ToString().TrimEnd();
        }

        //TODO Poblem 15

        //Problem 16 for Judge
        public static string RemoveTown(SoftUniContext context)
        {
            var townToDel = context
                .Towns
                .First(t => t.Name == "Seattle");

            var addressesToDel = context
                .Addresses
                .Where(a => a.TownId == townToDel.TownId);

            var addressesCount = addressesToDel.Count();

            var employeesOnDeletedAddresses = context
                .Employees
                .Where(e => addressesToDel
                    .Any(a => a.AddressId == e.AddressId));

            foreach (var e in employeesOnDeletedAddresses)
            {
                e.AddressId = null;
            }

            foreach (var address in addressesToDel)
            {
                context.Addresses.Remove(address);
            }

            context.Towns.Remove(townToDel);

            context.SaveChanges();

            var msg = $"{addressesCount} addresses in {townToDel.Name} were deleted";
            return msg;
        }

    }
}
