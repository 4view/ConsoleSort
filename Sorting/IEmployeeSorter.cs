using ConsoleSort.Model;

namespace ConsoleSort.Sorting;

public interface IEmployeeSorter
{
    public List<Employee> Sort(List<Employee> employees, string searchQuery);
}