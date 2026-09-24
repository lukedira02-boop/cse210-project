List<Video> videos =
[
    new Video("How to Bake Homemade Bread", "Kitchen Corner", 645),
    new Video("Beginner's Guide to Hiking", "Trail Explorer", 812),
    new Video("Understanding the Night Sky", "Clear Sky Science", 1030)
];

videos[0].AddComment(new Comment("Maria", "The step-by-step instructions were easy to follow."));
videos[0].AddComment(new Comment("James", "I made this recipe today and it turned out great!"));
videos[0].AddComment(new Comment("Priya", "The baking tips at the end were especially helpful."));

videos[1].AddComment(new Comment("Ethan", "This helped me prepare for my first hike."));
videos[1].AddComment(new Comment("Sofia", "I appreciate the checklist for beginners."));
videos[1].AddComment(new Comment("Lucas", "The advice about carrying water was useful."));

videos[2].AddComment(new Comment("Nora", "I finally understand how to find that constellation."));
videos[2].AddComment(new Comment("Daniel", "The explanation was clear and interesting."));
videos[2].AddComment(new Comment("Ava", "I am going outside to try this tonight."));

foreach (Video video in videos)
{
    Console.WriteLine($"Title: {video.GetTitle()}");
    Console.WriteLine($"Author: {video.GetAuthor()}");
    Console.WriteLine($"Length: {video.GetLength()} seconds");
    Console.WriteLine($"Comments: {video.GetNumberOfComments()}");

    foreach (Comment comment in video.GetComments())
    {
        Console.WriteLine($"- {comment.GetName()}: {comment.GetText()}");
    }

    Console.WriteLine();
}