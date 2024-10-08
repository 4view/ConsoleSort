namespace ConsoleSort.Model;

class EmployeeFactory
{
    public List<Employee> CreateEmployees(List<string> lines)
    {
        List<Employee> employees = new List<Employee>();

        foreach (string line in lines)
        {
            string[] item = line.Split(",");
            Employee empl = new Employee(item[0], item[1], item[2], Convert.ToInt32(item[3]), item[4].Split(";").ToList(), item[5]);
            employees.Add(empl);
        }
        return employees;
    }
}