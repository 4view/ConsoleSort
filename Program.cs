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
using ConsoleSort.Model;
using ConsoleSort.Sorting;
using ConsoleSort.Storage;

namespace ConsoleSort;

class Program
{
    static void Main(string[] args)
    {     
        //Console.WriteLine("ConsoleSort \nEnter a path to your file: ");
        string filePath = @"E:\temp\test\mytest.txt";

        var fileReader = new FileReader();
        var lines = fileReader.ReadText(filePath);

        // Считываем все с файла и записываем в переменную
        FileWriter emplWrite = new FileWriter();
        EmployeeFactory emplFactory = new EmployeeFactory();
        var employees = emplFactory.CreateEmployees(lines);

        Console.WriteLine("Enter a path where you want to save sort file: ");
        string resultFilePath = Console.ReadLine();
        SortBy? userChoice = null; // Перечисление выбора сортировки  

        Console.WriteLine("Choose a variation of the sort: \n1.FIO \n2.Age \n3.Language \n4.Position");
        userChoice = (SortBy)Convert.ToInt32(Console.ReadLine()); 

        SortFactory sorter = new SortFactory();
        var searchQuare = sorter.CreateSorter(userChoice); // По какому объекту (Фио, возвраст и тд.) будет проходить сортировка

        Console.WriteLine("Enter search query: ");
        string userQuery = Console.ReadLine(); // Параметр объекта

        SortContext sortby = new SortContext();
        var resultQuare = sortby.SortUsing(searchQuare, employees, userQuery);

        FileWriter fw = new FileWriter();
        fw.WriteEmployees(resultFilePath, resultQuare);

        if (File.Exists(resultFilePath) && new FileInfo(resultFilePath).Length != 0)
        {
            Console.WriteLine("File was successfuly sorted!");
        }
        if (File.Exists(resultFilePath) && new FileInfo(resultFilePath).Length == 0)
        {
            Console.WriteLine("Smth wrong or file empty!");
        }
        if (!File.Exists(resultFilePath))
        {
            Console.WriteLine("Failed to sort!");
            throw new Exception();
        }       
    }
}