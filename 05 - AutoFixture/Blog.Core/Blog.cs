using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Blog.Core
{
    public class User
    {
        public string Email { get; }
    }

    public interface IBlog
    {
        string Title { get; }
    }

    public class Blog : IBlog
    {
        public string Title { get; }
        public List<Post> Posts { get; set; }

        public Blog(string title, List<Post> posts)
        {
            Posts = posts;
            Title = title;
        }

        public Blog()
        {

        }

        public bool ExistPost(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException(nameof(title));

            return Posts.Any(x => x.Title.ToUpper() == title.ToUpper());
        }



    }
}