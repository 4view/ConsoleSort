public interface IEmployeeSorter
{
    public List<Employee> Sort(List<Employee> employees, string searchQuery);
}

public class NameEmployeeSorter : IEmployeeSorter
{
    public List<Employee> Sort(List<Employee> employees, string searchQuery) =>
        employees.Where(e => e.Name == searchQuery).ToList();
}
