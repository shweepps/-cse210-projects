// Base class for activities
public abstract class Activity
{
    protected int duration;

    protected Activity(int duration)
    {
        this.duration = duration;
    }

    public abstract void Start();

    protected void Pause(int seconds)
    {
        for (int i = seconds; i >= 0; i--)
        {
          
            Console.Write($"{i} ");
            Thread.Sleep(1000);
            Console.Write("\b\b");
           
        }
        Console.WriteLine();
    }
    protected void Animation(int seconds){
        List<string> AnimationStrings = new List<string>();
        
             AnimationStrings.Add("|");
             AnimationStrings.Add("/");
             AnimationStrings.Add("-");
            AnimationStrings.Add("\\");
             AnimationStrings.Add("|");
             AnimationStrings.Add("/");
             AnimationStrings.Add("-");
             AnimationStrings.Add("\\");
             AnimationStrings.Add("|");
             AnimationStrings.Add("/");
             AnimationStrings.Add("-");
           AnimationStrings.Add("\\");
            

        foreach (string i in AnimationStrings){

            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}
