class Program
{
    static void Main(string[] args)
    {

        Video video1 = new Video(
            "Learning C#",
            "Programming Channel",
            600);

        Video video2 = new Video(
            "How to Build a Website",
            "Web Development Channel",
            850);

        Video video3 = new Video(
            "Introduction to Object-Oriented Programming",
            "Coding Academy",
            720);

        video1.AddComment(new Comment(
            "Marco",
            "This video was very helpful!"));

        video1.AddComment(new Comment(
            "Daniel",
            "I learned a lot from this video."));

        video1.AddComment(new Comment(
            "Sofia",
            "The explanation was easy to understand."));


        video2.AddComment(new Comment(
            "Carlos",
            "The website examples were great."));

        video2.AddComment(new Comment(
            "Laura",
            "I am going to try this project."));

        video2.AddComment(new Comment(
            "James",
            "Very useful tutorial!"));


        video3.AddComment(new Comment(
            "Michael",
            "I finally understand classes better."));

        video3.AddComment(new Comment(
            "Emma",
            "The examples were really clear."));

        video3.AddComment(new Comment(
            "Alex",
            "Great introduction to OOP."));

        List<Video> videos = new List<Video>();

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}