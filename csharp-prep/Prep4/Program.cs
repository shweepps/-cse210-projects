using System;

class Program
{
    static void Main(string[] args)
    {
        var numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int num;
        do {
            Console.Write("Enter number: ");
            num = int.Parse(Console.ReadLine());
            if (num != 0) {
                numbers.Add(num);
            }
        } while (num != 0);

        int sum = numbers.Sum();
        double average = numbers.Average();
        int max = numbers.Max();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
    }
}