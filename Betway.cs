using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        Console.Write("Enter potion power level: ");
        int power = int.Parse(Console.ReadLine());
        Console.WriteLine(IsMagicalPotion(power) ? "YES" : "NO");
        Console.Write("Enter outcomes: ");
        int[] outcomes = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] duplicates = FindDuplicate(outcomes);
        Console.WriteLine($"[{duplicates[0]}, {duplicates[1]}]");
        Console.Write("Enter a string: ");
        string inputString = Console.ReadLine();
        string reformattedString = Reformat(inputString);
        Console.WriteLine(reformattedString);
        Console.Write("Enter book copies: ");
        int[] shelf = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(OrganizeBooks(shelf) ? "YES" : "NO");
    }

   
 static bool IsMagicalPotion(int power){
        if (power <= 0) return false;
        int root = (int)Math.Round(Math.Pow(power, 1.0 / 3.0));
        return root * root * root == power;
    }
    static int[] FindDuplicate(int[] outcomes){
        HashSet<int> seen = new HashSet<int>();
        List<int> duplicates = new List<int>();

        foreach (int outcome in outcomes){
            if (!seen.Add(outcome)) 
                duplicates.Add(outcome);

            if (duplicates.Count == 2) 
                break;
        }

        return duplicates.ToArray();
    }
    static string Reformat(string a){
        StringBuilder result = new StringBuilder();
        bool toUpper = true; 
        foreach (char b in a)
        {
            if (char.IsLetter(b))
            {
                result.Append(toUpper ? char.ToUpper(b) : char.ToLower(b));
                toUpper = !toUpper; 
            }
            else
            {
                result.Append(b);
            }
        }

        return result.ToString();
    }

    static bool OrganizeBooks(int[] shelf)
    {
        Dictionary<int, int> frequency = new Dictionary<int, int>();
        foreach (int book in shelf)
        {
            if (frequency.ContainsKey(book))
                frequency[book]++;
            else
                frequency[book] = 1;
        }
        int gcd = frequency.Values.Aggregate(GCD);
        return gcd > 1; 
    }
    static int GCD(int num1, int num2)
    {
        while (num2 != 0)
        {
            int temp = num2;
            num2 = num1 % num2;
            num1 = temp;
        }
        return num1;
    }
}
