class Video
{
    public string _title { get; set; }
    public string _author { get; set; }
    public int _lengthInSeconds { get; set; }
    private List<Comment> _comments { get; set; } = new List<Comment>();

    public void AddComment(string commenterName, string commentText)
    {
        Comment comment = new Comment { _commenterName = commenterName, _commentText = commentText };
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_lengthInSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
        
        if (GetNumberOfComments() > 0)
        {
            Console.WriteLine("Comments:");
            foreach (var comment in _comments)
            {
                Console.WriteLine($"  -{comment._commenterName}: {comment._commentText}");
            }
        }

        Console.WriteLine();
    }
}