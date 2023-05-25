public class Scripture
{
    private readonly string reference;
    private readonly string text;
    private readonly List<Word> words;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        this.text = text;
        this.words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.WriteLine(reference);

        foreach (Word word in words)
        {
            if (word.IsHidden)
            {
                Console.Write("___ ");
            }
            else
            {
                Console.Write(word.Text + " ");
            }
        }

        Console.WriteLine();
    }

    public void HideRandomWords(int count)
    {
        Random random = new Random();
        int hiddenCount = 0;

        while (hiddenCount < count)
        {
            int index = random.Next(0, words.Count);
            if (!words[index].IsHidden)
            {
                words[index].Hide();
                hiddenCount++;
            }
        }
    }

    public bool HasHiddenWords()
    {
        return words.Any(word => !word.IsHidden);
    }
}
