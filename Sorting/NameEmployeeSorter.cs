using ConsoleSort.Model;

namespace ConsoleSort.Sorting;

public class NameEmployeeSorter : IEmployeeSorter
{
    public List<Employee> Sort(List<Employee> employees, string searchQuery) =>
        employees.Where(e => e.Name == searchQuery).ToList();
}