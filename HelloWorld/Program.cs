/*

Code from: http://www.newthinktank.com/2015/07/learn-c-one-video/


*/


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ConsoleApplication2;

// Delegates are used to pass methods as arguments to other methods
// A delegate can represent a method with a similar return type and attribute list
delegate double GetSum(double num1, double num2);

// ---------- ENUMS ----------
// Enums are unique types with symbolic names and associated values

public enum Temperature
{
    Freeze,
    Low,
    Warm,
    Boil
}

// ---------- STRUCT ----------
// A struct is a custom type that holds data made up from different data types
struct Customers
{
    private string name;
    private double balance;
    private int id;

    public void createCust(string n, double b, int i)
    {
        name = n;
        balance = b;
        id = i;
    }

    public void showCust()
    {
        Console.WriteLine("Name : " + name);
        Console.WriteLine("Balance : " + balance);
        Console.WriteLine("ID : " + id);
    }
}

namespace HelloWorld
{
    class Program
    {
        // The ```Main``` method is a static method that resides inside a class or a struct.
        // The parameter of the Main method, args, is a string array that contains the 
        // command-line arguments used to invoke the program. Unlike in C++, the array 
        // does not include the name of the executable (exe) file.
        static void Main(string[] args)
        {
            // --------------- Basics ------------------
            // Simple Hello world
            Console.Write(":) "); //Doesn't end with a line break
            Console.WriteLine("Hello World!"); //Ends with a line break

            // Input-Output
            Console.Write("What is your favorite color? ");
            string color = Console.ReadLine();
            Console.WriteLine("Hey! " + color + " is a cool color");


            // Datatypes
            /*
             * bool
             * char - 16 bit unicode
             * int, long, decimal, float, double (listed in increasing order by max value, use datatype.MaxValue to get their size)
             */

            // String concatenation for data type conversion, the '+' works.
            int myNumber = 42;
            Console.WriteLine("What is the answer to life the universe and everything? It's " + myNumber);

            // var keyword - when used, assumes data type. Data type is static though, so once a var has a data type it won't change
            var someVariable = "A Dance With Dragons";
            Console.WriteLine("someVariable: " + someVariable + ", datatype: {0}", someVariable.GetTypeCode());


            // Type casting
            double numberPi = 3.14159;
            int intPi = (int)numberPi;


            // ---------- CONDITIONALS ----------

            // Relational Operators : > < >= <= == !=
            // Logical Operators : && || ^ !

            // If Statement
            int age = 17;

            if ((age >= 5) && (age <= 7))
            {
                Console.WriteLine("Go to elementary school");
            }
            else if ((age > 7) && (age < 13))
            {
                Console.WriteLine("Go to middle school");
            }
            else
            {
                Console.WriteLine("Go to high school");
            }

            if ((age < 14) || (age > 67))
            {
                Console.WriteLine("You shouldn't work");
            }

            Console.WriteLine("! true = " + (!true));

            // Ternary Operator

            bool canDrive = age >= 16 ? true : false;

            // Switch is used when you have limited options
            // Fall through isn't allowed with C# unless there are no statements between cases
            // You can't check multiple values at once

            switch (age)
            {
                case 0:
                    Console.WriteLine("Infant");
                    break;
                case 1:
                case 2:
                    Console.WriteLine("Toddler");

                    // Goto can be used to jump to a label elsewhere in the code
                    goto Cute;
                default:
                    Console.WriteLine("Child");
                    break;
            }

        // Lable we can jump to with Goto
        Cute:
            Console.WriteLine("Toddlers are cute");

            // ---------- LOOPING ----------

            int i = 0;

            while (i < 10)
            {
                // If i = 7 then skip the rest of the code and start with i = 8
                if (i == 7)
                {
                    i++;
                    continue;
                }

                // Jump completely out of the loop if i = 9
                if (i == 9)
                {
                    break;
                }

                // You can't convert an int into a bool : Print out only odds
                if ((i % 2) > 0)
                {
                    Console.WriteLine(i);
                }
                i++;
            }

            // The do while loop will go through the loop at least once
            string guess;
            do
            {
                Console.WriteLine("Guess a Number ");
                guess = Console.ReadLine();
            } while (!guess.Equals("15")); // How to check String equality

            // Puts all changes to the iterator in one place
            for (int j = 0; j < 10; j++)
            {
                if ((j % 2) > 0)
                {
                    Console.WriteLine(j);
                }
            }

            // foreach cycles through every item in an array or collection
            string randStr = "Here are some random characters";

            foreach (char c in randStr)
            {
                Console.WriteLine(c);
            }

            // ---------- STRINGS ----------

            // Escape Sequences : \' \" \\ \b \n \t

            string sampString = "A bunch of random words";

            // Check if empty
            Console.WriteLine("Is empty " + String.IsNullOrEmpty(sampString));
            Console.WriteLine("Is empty " + String.IsNullOrWhiteSpace(sampString));
            Console.WriteLine("String Length " + sampString.Length);

            // Find a string index (Starts with 0)
            Console.WriteLine("Index of bunch " + sampString.IndexOf("bunch"));

            // Get a substring
            Console.WriteLine("2nd Word " + sampString.Substring(2, 6));

            string sampString2 = "More random words";

            // Are strings equal
            Console.WriteLine("Strings equal " + sampString.Equals(sampString2));

            // Compare strings
            Console.WriteLine("Starts with A bunch " + sampString.StartsWith("A bunch"));
            Console.WriteLine("Ends with words " + sampString.EndsWith("words"));

            // Trim white space at beginning and end or (TrimEnd / TrimStart)
            sampString = sampString.Trim();

            // Replace words or characters
            sampString = sampString.Replace("words", "characters");
            Console.WriteLine(sampString);

            // Remove starting at a defined index up to the second index
            sampString = sampString.Remove(0, 2);
            Console.WriteLine(sampString);

            // Join values in array and save to string
            string[] names = new string[3] { "Matt", "Joe", "Paul" };
            Console.WriteLine("Name List " + String.Join(", ", names));

            // Formatting : Currency, Decimal Places, Before Decimals, Thousands Separator
            string fmtStr = String.Format("{0:c} {1:00.00} {2:#.00} {3:0,0}", 1.56, 15.567, .56, 1000);

            Console.WriteLine(fmtStr.ToString());

            // ---------- STRINGBUILDER ----------
            // Each time you create a string you actually create another string in memory
            // StringBuilders are used when you want to be able to edit a string without creating new ones

            StringBuilder sb = new StringBuilder();

            // Append a string to the StringBuilder (AppendLine also adds a newline at the end)
            sb.Append("This is the first sentence.");

            // Append a formatted string
            sb.AppendFormat("My name is {0} and I live in {1}", "Derek", "Pennsylvania");

            // Clear the StringBuilder
            // sb.Clear();

            // Replaces every instance of the first with the second
            sb.Replace("a", "e");

            // Remove characters starting at the index and then up to the defined index
            sb.Remove(5, 7);

            // Out put everything
            Console.WriteLine(sb.ToString());

            // ---------- ARRAYS ----------
            // Declare an array
            int[] randNumArray;

            // Declare the number of items an array can contain
            int[] randArray = new int[5];

            // Declare and initialize an array
            int[] randArray2 = { 1, 2, 3, 4, 5 };

            // Get array length
            Console.WriteLine("Array Length " + randArray2.Length);

            // Get item at index
            Console.WriteLine("Item 0 " + randArray2[0]);

            // Cycle through array
            for (int j = 0; j < randArray2.Length; j++)
            {
                Console.WriteLine("{0} : {1}", j, randArray2[j]);
            }

            // Cycle with foreach
            foreach (int num in randArray2)
            {
                Console.WriteLine(num);
            }

            // Get the index of an item or -1
            Console.WriteLine("Where is 1 " + Array.IndexOf(randArray2, 1));

            string[] names2 = { "Tom", "Paul", "Sally" };

            // Join an array into a string
            string nameStr = string.Join(", ", names2);
            Console.WriteLine(nameStr);

            // Split a string into an array
            string[] nameArray = nameStr.Split(',');

            // Create a multidimensional array
            int[,] multArray = new int[5, 3];

            // Create and initialize a multidimensional array
            int[,] multArray2 = { { 0, 1 }, { 2, 3 }, { 4, 5 } };

            // Cycle through multidimensional array
            foreach (int num in multArray2)
            {
                Console.WriteLine(num);
            }

            // Cycle and have access to indexes
            for (int x = 0; x < multArray2.GetLength(0); x += 1)
            {
                for (int y = 0; y < multArray2.GetLength(1); y += 1)
                {
                    Console.WriteLine("{0} | {1} : {2}", x, y, multArray2[x, y]);
                }
            }

            // ---------- LISTS ----------
            // A list unlike an array automatically resizes

            // Create a list and add values
            List<int> numList = new List<int>();
            numList.Add(5);
            numList.Add(15);
            numList.Add(25);

            // Add an array to a list
            int[] randArray3 = { 1, 2, 3, 4, 5 };
            numList.AddRange(randArray3);

            // Clear a list
            // numList.Clear();

            // Copy an array into a List
            List<int> numList2 = new List<int>(randArray3);

            // Create a List with array
            List<int> numList3 = new List<int>(new int[] { 1, 2, 3, 4 });

            // Insert in a specific index
            numList.Insert(1, 10);

            // Remove a specific value
            numList.Remove(5);

            // Remove at an index
            numList.RemoveAt(2);

            // Cycle through a List with foreach or
            for (int j = 0; j < numList.Count; j++)
            {
                Console.WriteLine(numList[j]);
            }

            // Return the index for a value or -1
            Console.WriteLine("4 is in index " + numList3.IndexOf(4));

            // Does the List contain a value
            Console.WriteLine("5 in list " + numList3.Contains(5));

            // Search for a value in a string List
            List<string> strList = new List<string>(new string[] { "Tom", "Paul" });
            Console.WriteLine("Tom in list " + strList.Contains("tom", StringComparer.OrdinalIgnoreCase));

            // Sort the List
            strList.Sort();

            // ---------- EXCEPTION HANDLING ----------
            // All the exceptions 
            // msdn.microsoft.com/en-us/library/system.systemexception.aspx#inheritanceContinued

            try
            {
                Console.Write("Divide 10 by ");
                int num = int.Parse(Console.ReadLine());
                Console.WriteLine("10 / {0} =  {1}", num, (10 / num));

            }

            // Specifically catches the divide by zero exception
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Can't divide by zero");

                // Get additonal info on the exception
                Console.WriteLine(ex.GetType().Name);
                Console.WriteLine(ex.Message);

                // Throw the exception to the next inline
                // throw ex;

                // Throw a specific exception
                throw new InvalidOperationException("Operation Failed", ex);
            }

            // Catches any other exception
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(ex.GetType().Name);
                Console.WriteLine(ex.Message);
            }

            // ---------- CLASSES & OBJECTS ----------

            Animal bulldog = new Animal(13, 50, "Spot", "Woof");

            Console.WriteLine("{0} says {1}", bulldog.name, bulldog.sound);

            bulldog.RunAnimal();

            // Console.WriteLine("No. of Animals " + Animal.getNumOfAnimals());

            // ---------- ENUMS ----------

            Temperature micTemp = Temperature.Low;
            Console.Write("What Temp : ");

            Console.ReadLine();

            switch (micTemp)
            {
                case Temperature.Freeze:
                    Console.WriteLine("Temp on Freezing");
                    break;

                case Temperature.Low:
                    Console.WriteLine("Temp on Low");
                    break;

                case Temperature.Warm:
                    Console.WriteLine("Temp on Warm");
                    break;

                case Temperature.Boil:
                    Console.WriteLine("Temp on Boil");
                    break;
            }

            // ---------- STRUCTS ----------
            Customers bob = new Customers();

            bob.createCust("Bob", 15.50, 12345);

            bob.showCust();

            // ---------- ANONYMOUS METHODS ----------
            // An anonymous method has no name and its return type is defined by the return used in the method

            GetSum sum = delegate (double num1, double num2)
            {
                return num1 + num2;
            };

            Console.WriteLine("5 + 10 = " + sum(5, 10));

            // ---------- LAMBDA EXPRESSIONS ----------
            // A lambda expression is used to act as an anonymous function or expression tree

            // You can assign the lambda expression to a function instance
            Func<int, int, int> getSum = (x, y) => x + y;
            Console.WriteLine("5 + 3 = " + getSum.Invoke(5, 3));

            // Get odd numbers from a list
            List<int> numList4 = new List<int> { 5, 10, 15, 20, 25 };

            // With an Expression Lambda the input goes in the left (n) and the statements go on the right
            List<int> oddNums = numList4.Where(n => n % 2 == 1).ToList();

            foreach (int num in oddNums)
            {
                Console.Write(num + ", ");
            }

            // ---------- FILE I/O ----------
            // The StreamReader and StreamWriter allows you to create text files while reading and 
            // writing to them

            string[] custs = new string[] { "Tom", "Paul", "Greg" };

            using (StreamWriter sw = new StreamWriter("custs.txt"))
            {
                foreach (string cust in custs)
                {
                    sw.WriteLine(cust);
                }
            }

            string custName = "";
            using (StreamReader sr = new StreamReader("custs.txt"))
            {
                while ((custName = sr.ReadLine()) != null)
                {
                    Console.WriteLine(custName);
                }
            }


            //------------------Animal Class-------------------------
            // Create an Animal object and call the constructor
            Animal spot = new Animal(15, 10, "Spot", "Woof");

            // Get object values with the dot operator
            Console.WriteLine("{0} says {1}", spot.name, spot.sound);

            // Calling a static method
            Console.WriteLine("Number of Animals " + Animal.getNumOfAnimals());

            // Calling an object method
            Console.WriteLine(spot.toString());

            Console.WriteLine("3 + 4 = " + spot.getSum(3, 4));

            // You can assign attributes by name
            Console.WriteLine("3.4 + 4.5 = " + spot.getSum(num2: 3.4, num1: 4.5));

            // You can create objects with an object initializer
            Animal grover = new Animal
            {
                name = "Grover",
                height = 16,
                weight = 18,
                sound = "Grrr"
            };

            Console.WriteLine(grover.toString());

            // Create a subclass Dog object
            Dog spike = new Dog();

            Console.WriteLine(spike.toString());

            spike = new Dog(20, 15, "Spike", "Grrr Woof", "Chicken");

            Console.WriteLine(spike.toString());

            // One way to implement polymorphism is through an abstract class
            Shape rect = new Rectangle(5, 5);
            Shape tri = new Triangle(5, 5);
            Console.WriteLine("Rect Area " + rect.area());
            Console.WriteLine("Trit Area " + tri.area());

            // Using the overloaded + on 2 Rectangles
            Rectangle combRect = new Rectangle(5, 5) + new Rectangle(5, 5);

            Console.WriteLine("combRect Area = " + combRect.area());

            // ---------- GENERICS ----------
            // With Generics you don't have to specify the data type of an element in a class or method
            KeyValue<string, string> superman = new KeyValue<string, string>("", "");
            superman.key = "Superman";
            superman.value = "Clark Kent";
            superman.showData();

            // Now use completely different types
            KeyValue<int, string> samsungTV = new KeyValue<int, string>(0, "");
            samsungTV.key = 123456;
            samsungTV.value = "a 50in Samsung TV";
            samsungTV.showData();

            Console.Write("Hit Enter to Exit");

        }
    }
}
