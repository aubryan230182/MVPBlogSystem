using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVPWebApiRESTfulJSON.Entity
{
    public class Blog
    {
        public Blog()
        {
            //BlogComment = new List<Comment>();
            BlogCategory = new Category();
            BlogAuthor = new Author();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }

        public Category BlogCategory { get; set; }
        public Author BlogAuthor { get; set; }

        //public ICollection<Comment> BlogComment { get; set; }
    }
}