using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVPWebApiRESTfulJSON.Entity
{
    public class Comment
    {
        public Comment()
        {
            CommentAuthor = new List<Author>();
        }

        public int Id { get; set; }
        public string Body { get; set; }

        public ICollection<Author> CommentAuthor { get; set; }
    }
}