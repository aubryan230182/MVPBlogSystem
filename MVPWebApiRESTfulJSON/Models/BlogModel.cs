using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVPWebApiRESTfulJSON.Entity;

namespace MVPWebApiRESTfulJSON.Models
{
    public class BlogModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }

        public CategoryModel Category { get; set; }
        public AuthorModel Author { get; set; }
    }
}