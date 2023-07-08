using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<MediaContent> videos = new List<MediaContent>();

        // Create videos and add comments
        MediaContent video1 = new Video()
        {
            Title = "Video 1",
            Author = "Author 1",
            Length = 120
        };
        ((Video)video1).AddComment(new Comment() { Name = "User 1", Text = "Comment 1" });
        ((Video)video1).AddComment(new Comment() { Name = "User 2", Text = "Comment 2" });
        ((Video)video1).AddComment(new Comment() { Name = "User 3", Text = "Comment 3" });

        MediaContent video2 = new Video()
        {
            Title = "Video 2",
            Author = "Author 2",
            Length = 180
        };
        ((Video)video2).AddComment(new Comment() { Name = "User 1", Text = "Comment 1" });
        ((Video)video2).AddComment(new Comment() { Name = "User 2", Text = "Comment 2" });
        ((Video)video2).AddComment(new Comment() { Name = "User 3", Text = "Comment 3" });

        MediaContent video3 = new Video()
        {
            Title = "Video 3",
            Author = "Author 3",
            Length = 240
        };
        ((Video)video3).AddComment(new Comment() { Name = "User 1", Text = "Comment 1" });
        ((Video)video3).AddComment(new Comment() { Name = "User 2", Text = "Comment 2" });
        ((Video)video3).AddComment(new Comment() { Name = "User 3", Text = "Comment 3" });

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Display video information
        foreach (var video in videos)
        {
            video.Display();
        }

        Console.ReadLine();
    }
}
