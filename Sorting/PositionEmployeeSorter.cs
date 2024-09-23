using ConsoleSort.Model;

namespace ConsoleSort.Sorting;

public class PositionEmployeeSorter : IEmployeeSorter
{
    public List<Employee> Sort(List<Employee> employees, string searchQuery) =>
        employees.Where(e => e.Position == searchQuery).ToList();
}