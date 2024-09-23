namespace ConsoleSort.Model;

public class Employee 
{
    public Employee (string secondName, string name, string thirdName, int age, List<string> language, string position)
    {
        SecondName = secondName.Trim();
        Name = name.Trim();
        ThirdName = thirdName.Trim();
        Age = age;
        Language = language.Select(l => l.Trim()).ToList();
        Position = position.Trim();
    }

    public string SecondName { get; }

    public string Name { get; }

    public string ThirdName { get; }

    public int Age { get; }

    public List<string> Language { get; }

    public string Position { get; }

    public override string ToString()
    {
        string myLanguage = string.Join(' ', Language);
        return   "SecondName: " + SecondName + "\nName: " + Name + "\nThirdName: " + ThirdName + "\nAge: " + Age + "\nLanguages: " + myLanguage + "\nPosition: " + Position + "\n" + "-------------------------------------";
    }
}