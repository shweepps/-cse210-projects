using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Running running = new Running("03 Nov 2022", 30, 3.0);
        Cycling cycling = new Cycling("03 Nov 2022", 30, 15);
        Swimming swimming = new Swimming("03 Nov 2022", 30, 10);

        List<Activity> activities = new List<Activity>
        {
            running,
            cycling,
            swimming
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
