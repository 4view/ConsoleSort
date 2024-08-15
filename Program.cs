using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System;
using System.Text;
using System.Transactions;
using System.Security.Principal;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.Unicode;
using System.Runtime;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Dynamic;
using System.Net.WebSockets;

class Program

{
    static void Main(string[] args)
    {       
        Console.WriteLine("ConsoleSort \nEnter a path to your file: ");
        string? filePath = Console.ReadLine();
        //Кароче я создал метод в EmployeeFactory WriteEmployees, для записи отсортированных работников, дальше я прономерую вопросы...
        //1. Можно ли/ правильно ли создавать этот метод в этом классе или лучше создать отдельный класс 
        //2. Если все таки можно так делать, я создаю новый экземпляр класса emplWrite а потом уже в нужном кейсе юзаю метод, правильно ли это или нужно создавать каждому кейсу объект, хотя звучит как бред
        //3. Ну и если где-то совсем корявые названия напиши где, я пытался нормальные делать. И ваще чиркани где ошибки

        var fileReader = new FileReader();
        var lines = fileReader.ReadText(filePath);

        EmployeeFactory emplWrite = new EmployeeFactory();
        EmployeeFactory emplFactory = new EmployeeFactory();
        var employees = emplFactory.CreateEmployees(lines);

        Console.WriteLine("Choose a variation of the sort: \n1.FIO \n2.Age \n3.Language \n4.Position \n5.Test sort");
        int userChoice = Convert.ToInt32(Console.ReadLine());       
                
        switch (userChoice)
        {
            case 1:
            {
                Console.WriteLine("Choose a variation: \n1.Name \n2.SecondNamde \n3.TherdName");
                int innerChoice = Convert.ToInt32(Console.ReadLine());
                switch(innerChoice)
                {
                    case 1:
                    {                       
                        Console.WriteLine("Enter the name of sort: ");
                        string? userName = Console.ReadLine();                                              

                        var selectedEmploeeys = employees.Where(e => e.Name == userName);
                        
                        var writeEmployees = emplWrite.WriteEmployees(selectedEmploeeys.ToList());

                        Console.WriteLine("Enter a path where you want to save sort file: ");  
                        string? outFile = Console.ReadLine();

                        File.WriteAllLines(outFile, writeEmployees);
                        Console.WriteLine("Sort is successfully done!");
                        break;
                    }
                    case 2: 
                    {
                        Console.WriteLine("Enter a secondName of sort: ");
                        string? userSecondName = Console.ReadLine();

                        var selectedEmploeeys = employees.Where(e => e.SecondName == userSecondName);

                        var writeEmployees = emplWrite.WriteEmployees(selectedEmploeeys.ToList());
                        
                        Console.WriteLine("Enter a path where you want to save sort file: ");
                        string? outFile = Console.ReadLine();

                        File.WriteAllLines(outFile, writeEmployees);
                        Console.WriteLine("Sort is successfully done!");
                        break;
                    }
                    case 3: 
                    {
                        Console.WriteLine("Enter a therdname of sort: ");
                        string? userThirdName = Console.ReadLine();

                        var selectedEmploeeys = employees.Where(e => e.ThirdName == userThirdName);

                        List<string> outContent = new List<string>();

                        foreach (Employee empl in selectedEmploeeys)
                        {
                            outContent.Add(empl.ToString());
                        }

                        Console.WriteLine("Enter a path where you want to save sort file: ");
                        string? outFile = Console.ReadLine();

                        File.WriteAllLines(outFile, outContent);
                        Console.WriteLine("Sort is successfuly done!");
                        break;
                    }
                }
                break;
            }
            case 2:
            {
                Console.WriteLine("Enter an age of emploeeyr:");
                int userAge = Convert.ToInt32(Console.ReadLine());

                var selectedEmploeeys = employees.Where(e => e.Age == userAge);

                List<string> outContent = new List<string>();

                foreach (Employee empl in selectedEmploeeys)
                {
                    outContent.Add(empl.ToString());
                }

                Console.WriteLine("Enter a path to save file: ");
                string? outFile = Console.ReadLine();

                File.WriteAllLines(outFile, outContent);
                Console.WriteLine("Sort was successfuly done!");
                break;
            }
            case 3:
            {
                Console.WriteLine("Enter a language: ");
                string? userLanguage = Console.ReadLine();

                var selectedEmploeeys = employees.Where(e => e.Language.Contains(userLanguage));

                List<string> outContent = new List<string>();

                foreach (Employee empl in selectedEmploeeys)
                {
                    outContent.Add(empl.ToString());
                }

                Console.WriteLine("Enter a path to save file: ");
                string? outFile = Console.ReadLine();
                
                File.WriteAllLines(outFile, outContent);
                Console.WriteLine("Sort was successfuly done!");

                break;
            }
            case 4:
            {
                Console.WriteLine("Enter a position: ");
                string? userPosition = Console.ReadLine();

                var selectedEmploeeys = employees.Where(e => e.Position == userPosition);

                List<string> outContetnt = new List<string>();

                foreach (Employee empl in selectedEmploeeys)
                {
                    outContetnt.Add(empl.ToString());
                }

                Console.WriteLine("Enter a path to save file: ");
                string? outFile = Console.ReadLine();

                File.WriteAllLines(outFile, outContetnt);
                Console.WriteLine("Sort was successfuly done!");

                break;
            }
            case 5:
            {
                string outFile = @"E:\temp\test\sort.txt";             

                List<string> outContent = new List<string>();//Коллекция для выводы отсортированного содержимого 

                foreach (Employee empl in employees)
                {
                    outContent.Add(empl.ToString());
                    //Console.WriteLine(empl);
                }                

                File.WriteAllLines(outFile, outContent);
                Console.WriteLine("Sort is successfully done!");
                break;
            }
        }      

        
    }
}

//Есть документ с данными компаний их работников (ФИО, возвраст, язык, должность), нужно отсортировать по любому параметру сотрудника. 