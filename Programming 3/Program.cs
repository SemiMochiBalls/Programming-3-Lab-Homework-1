using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Programming_3;

public static class StringBuilderExtensions
{
    public static int WordCount(this StringBuilder stringBuilder)
    {
        if (stringBuilder == null)
            throw new ArgumentNullException(nameof(stringBuilder));

        int wordCount = 0;
        bool inWord = false;

        for (int i = 0; i < stringBuilder.Length; i++)
        {
            char c = stringBuilder[i];

            if (char.IsWhiteSpace(c))
            {
                // If we were in a word, increment the word count
                if (inWord)
                {
                    wordCount++;
                    inWord = false;
                }
            }
            else
            {
                inWord = true;
            }
        }

        // Check if there's a word at the end of the StringBuilder
        if (inWord)
        {
            wordCount++;
        }

        return wordCount;
    }
}

class Program
{
    static void Main()
    {
        // Demonstrating Arrays vs. Linked Lists
        Console.WriteLine("Arrays vs. Linked Lists:");
        Console.WriteLine("------------------------");

        // Array
        int[] array = new int[] { 1, 2, 3, 4, 5 };
        Console.WriteLine("Array:");
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        // Linked List
        LinkedList<int> linkedList = new LinkedList<int>();
        linkedList.AddLast(1);
        linkedList.AddLast(2);
        linkedList.AddLast(3);
        linkedList.AddLast(4);
        linkedList.AddLast(5);

        Console.WriteLine("Linked List:");
        foreach (var item in linkedList)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
        Console.WriteLine();

        // Stack
        Stack<int> stack = new Stack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        Console.WriteLine("Stack (Last-In, First-Out):");
        while (stack.Count > 0)
        {
            Console.Write(stack.Pop() + " ");
        }
        Console.WriteLine();

        // Queue
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        Console.WriteLine("Queue (First-In, First-Out):");
        while (queue.Count > 0)
        {
            Console.Write(queue.Dequeue() + " ");
        }
        Console.WriteLine();
        Console.WriteLine();

        // Demonstrating Type Constraints
        Console.WriteLine("Type Constraints:");
        Console.WriteLine("-----------------");

        // Generic method with type constraint
        Console.WriteLine("Max Value: " + GetMax(5, 10));
        Console.WriteLine("Max Value: " + GetMax("abc", "xyz"));

        Console.WriteLine("Please press enter to continue to question 2");
        Console.ReadLine();

        // Demonstrating Extension Method
        Console.WriteLine("Extension Method - Word Count:");
        Console.WriteLine("--------------------------------");

        StringBuilder sb = new StringBuilder("This is to test whether the extension method count can return a right answer or not");
        int wordCount = sb.WordCount();
        Console.WriteLine($"Number of words in the StringBuilder: {wordCount}");

        Console.WriteLine("Please press enter to continue to question 3");
        Console.ReadLine();


        MedalistManager manager = new MedalistManager();
        manager.LoadData("Medals.csv");

        while (true)
        {
            Console.WriteLine("Options:");
            Console.WriteLine("1. Add Medalist");
            Console.WriteLine("2. Delete Medalist");
            Console.WriteLine("3. Search Medalist");
            Console.WriteLine("4. Display All Medalists");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Country: ");
                        string country = Console.ReadLine();
                        Console.Write("Enter Year: ");

                        if (int.TryParse(Console.ReadLine(), out int year) &&
                            int.TryParse(Console.ReadLine(), out int goldMedals) &&
                            int.TryParse(Console.ReadLine(), out int silverMedals) &&
                            int.TryParse(Console.ReadLine(), out int bronzeMedals))
                        {
                            Console.Write("Enter Sport: ");
                            string sport = Console.ReadLine();
                            manager.AddMedalist(new Medalist { Athlete = name, Year = year, GoldMedals = goldMedals, SilverMedals = silverMedals, BronzeMedals = bronzeMedals });
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for year or medal counts.");
                        }
                        break;

                    case 2:
                        Console.Write("Enter Name to Delete: ");
                        string nameToDelete = Console.ReadLine();
                        manager.DeleteMedalist(nameToDelete);
                        break;

                    case 3:
                        Console.Write("Enter Search Key: ");
                        string searchKey = Console.ReadLine();
                        var searchResults = manager.SearchMedalists(searchKey);
                        Console.WriteLine("Search Results:");
                        foreach (var result in searchResults)
                        {
                            Console.WriteLine($"Athlete: {result.Athlete}, Year: {result.Year}, Gold Medals: {result.GoldMedals}, Silver Medals: {result.SilverMedals}, Bronze Medals: {result.BronzeMedals}");
                        }
                        break;

                    case 4:
                        manager.DisplayMedalists();
                        break;

                    case 5:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid choice.");
            }
        }
    }
    

    private static T GetMax<T>(T a, T b) where T : IComparable<T> => a.CompareTo(b) > 0 ? a : b;
}
