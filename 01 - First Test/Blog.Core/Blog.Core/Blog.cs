using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Core
{
    public class Blog
    {
        public string Title { get; set; }
        public IReadOnlyCollection<Post> Posts => _posts.AsReadOnly();
        private List<Post> _posts = new List<Post>();

        public Blog(string title, List<Post> posts)
        {
            _posts = posts;
            Title = title;
        }

        public Blog()
        {

        }

        public bool ExistPost(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException(nameof(title));

            return _posts.Any(x => x.Title.ToUpper() == title.ToUpper());
        }



    }
}