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
        Console.Write("Enter outcomes separated by space: ");
        int[] outcomes = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] duplicates = FindDuplicateOutcomes(outcomes);
        Console.WriteLine($"[{duplicates[0]}, {duplicates[1]}]");
        Console.Write("Enter a string to reformat: ");
        string inputString = Console.ReadLine();
        string reformattedString = ReformatAlternatingCase(inputString);
        Console.WriteLine(reformattedString);
        Console.Write("Enter book copies on the shelf separated by space: ");
        int[] shelf = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(CanOrganizeBooks(shelf) ? "YES" : "NO");
    }

   
 static bool IsMagicalPotion(int power){
        if (power <= 0) return false;
        int root = (int)Math.Round(Math.Pow(power, 1.0 / 3.0));
        return root * root * root == power;
    }
    static int[] FindDuplicateOutcomes(int[] outcomes){
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
    static string ReformatAlternatingCase(string s){
        StringBuilder result = new StringBuilder();
        bool toUpper = true; 
        foreach (char c in s)
        {
            if (char.IsLetter(c))
            {
                result.Append(toUpper ? char.ToUpper(c) : char.ToLower(c));
                toUpper = !toUpper; 
            }
            else
            {
                result.Append(c);
            }
        }

        return result.ToString();
    }

    static bool CanOrganizeBooks(int[] shelf)
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
    static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}