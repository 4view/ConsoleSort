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
        //Console.WriteLine("ConsoleSort \nEnter a path to your file: ");
        string filePath = @"E:\temp\test\mytest.txt";

        var fileReader = new FileReader();
        var lines = fileReader.ReadText(filePath);

        FileWriter emplWrite = new FileWriter();
        EmployeeFactory emplFactory = new EmployeeFactory();
        var employees = emplFactory.CreateEmployees(lines);

        Console.WriteLine("Enter a path where you want to save sort file: ");
        string resultFilePath = Console.ReadLine();
        SortBy? userChoice = null;// Перечисление выбора сортировки       

        try
        {
            Console.WriteLine("Choose a variation of the sort: \n1.FIO \n2.Age \n3.Language \n4.Position");
            userChoice = (SortBy)Convert.ToInt32(Console.ReadLine());
        }
        catch(Exception e)
        {
            Console.WriteLine("Enter correct variation!\n", e.Message);
            return;
        }       

        switch (userChoice)
        {
            case SortBy.FIO:
            {
                Console.WriteLine("Choose a variation: \n1.Name \n2.SecondNamde \n3.TherdName");
                int innerChoice = Convert.ToInt32(Console.ReadLine());
                switch(innerChoice)
                {
                    case 1:
                    {                       
                        Console.WriteLine("Enter the name of sort: ");
                        string userName = Console.ReadLine();         

                        NameEmployeeSorter SNempl = new NameEmployeeSorter();
                        var selectedEmploeeys = SNempl.Sort(employees, userName);
                    
                        emplWrite.WriteEmployees(resultFilePath, selectedEmploeeys);
                        Console.WriteLine("Sort is successfully done!");
                        break;
                    }
                    case 2: 
                    {
                        Console.WriteLine("Enter a secondName of sort: ");
                        string userSecondName = Console.ReadLine();

                        var selectedEmploeeys = employees.Where(e => e.SecondName == userSecondName);

                        emplWrite.WriteEmployees(resultFilePath, selectedEmploeeys.ToList());                        
                        Console.WriteLine("Sort is successfully done!");
                        break;
                    }
                    case 3: 
                    {
                        Console.WriteLine("Enter a therdname of sort: ");
                        string userThirdName = Console.ReadLine();

                        var selectedEmploeeys = employees.Where(e => e.ThirdName == userThirdName);  

                        emplWrite.WriteEmployees(resultFilePath, selectedEmploeeys.ToList());
                        Console.WriteLine("Sort is successfuly done!");
                        break;
                    }
                }
                    break;
                }
            case SortBy.Age:
            {
                Console.WriteLine("Enter an age of emploeeyr:");
                int userAge = Convert.ToInt32(Console.ReadLine());

                var selectedEmploeeys = employees.Where(e => e.Age == userAge);

                emplWrite.WriteEmployees(resultFilePath, selectedEmploeeys.ToList());
                Console.WriteLine("Sort was successfuly done!");
                break;
            }
            case SortBy.Language:
            {
                Console.WriteLine("Enter a language: ");
                string userLanguage = Console.ReadLine();

                var selectedEmploeeys = employees.Where(e => e.Language.Contains(userLanguage));

                emplWrite.WriteEmployees(resultFilePath, selectedEmploeeys.ToList());
                Console.WriteLine("Sort was successfuly done!");
                break;
            }
            case SortBy.Position:
            {
                Console.WriteLine("Enter a position: ");
                string userPosition = Console.ReadLine();

                var selectedEmploeeys = employees.Where(e => e.Position == userPosition);

                emplWrite.WriteEmployees(resultFilePath, selectedEmploeeys.ToList());
                Console.WriteLine("Sort was successfuly done!");
                break;
            }
        } 
    }

    public enum SortBy
    {
        FIO = 1,
        Age = 2,
        Language = 3,
        Position = 4,
    }
}

//Есть документ с данными компаний их работников (ФИО, возвраст, язык, должность), нужно отсортировать по любому параметру сотрудника. 