using System;

// Abstract class for media content
abstract class MediaContent
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }

    public abstract void Display();
}
