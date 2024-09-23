using ConsoleSort.Model; 

namespace ConsoleSort.Sorting;

public class AgeEmployeeSorter : IEmployeeSorter
{
    public List<Employee> Sort(List<Employee> employees, string searchQuery) =>
        employees.Where(e => e.Age == int.Parse(searchQuery)).ToList();
}
