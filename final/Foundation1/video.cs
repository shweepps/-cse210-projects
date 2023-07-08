using System;
using System.Collections.Generic;

// Video class inheriting from MediaContent
class Video : MediaContent
{
    public List<Comment> comments;

    public Video()
    {
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public override void Display()
    {
        Console.WriteLine("Title: " + Title);
        Console.WriteLine("Author: " + Author);
        Console.WriteLine("Length: " + Length + " seconds");
        Console.WriteLine("Number of Comments: " + GetNumberOfComments());

        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            Console.WriteLine(comment.Name + ": " + comment.Text);
        }

        Console.WriteLine();
    }
}
