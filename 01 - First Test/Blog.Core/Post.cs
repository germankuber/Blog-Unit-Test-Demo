using System;

namespace Blog.Core
{
    public class Post
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public Post(string title, string description, DateTime date)
        {
            Title = title;
            Description = description;
            Date = date;
        }
    }
}
