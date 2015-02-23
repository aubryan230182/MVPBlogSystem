using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVPWebApiRESTfulJSON.Entity;
using MVPWebApiRESTfulJSON.DAL;

namespace MVPWebApiRESTfulJSON.Models
{
    public class ModelFactory
    {
        // nice to have if can implement Repository pattern
        private MVPContext _ctx = new MVPContext();

        public BlogModel Create(Blog blog)
        {
            return new BlogModel()
            {
                Id = blog.Id,
                Title = blog.Title,
                SubTitle = blog.SubTitle,
                Tags = blog.Tags,
                Content = blog.Content,
                Category = Create(blog.BlogCategory),
                Author = Create(blog.BlogAuthor),
            };
        }

        public CategoryModel Create(Category category)
        {
            return new CategoryModel()
            {
                Id = category.Id,
                Name = category.Name
                
            };
        }

        public AuthorModel Create(Author author)
        {
            return new AuthorModel()
            {
                Id = author.Id,
                Email = author.Email,
                FirstName = author.FirstName,
                LastName = author.LastName,
            };
        }

        public Blog Parse(BlogModel model)
        {
            try
            {
                var blog = new Blog()
                {
                    Title = model.Title,
                    SubTitle = model.SubTitle,
                    Tags = model.Tags,
                    Content = model.Content,
                    BlogCategory = _ctx.Categories.Find(model.Category.Id),
                    BlogAuthor = _ctx.Authors.Find(model.Author.Id),
                };

                return blog;
            }
            catch (Exception)
            {

                return null;
            }
        }

        // Repository pattern should be implemented, which is ideal. 

        public bool LoginMVP(string userName, string password)
        {
            var author = _ctx.Authors.Where(s => s.UserName == userName).SingleOrDefault();

            if (author != null)
            {
                if (author.Password == password)
                {
                    return true;
                }
            }

            return false;
        }

        public IQueryable<Blog> GetAllBlogs()
        {
            return _ctx.Blogs
                    .Include("BlogCategory")
                    .Include("BlogAuthor")
                    .AsQueryable();
        }

        public Blog GetBlog(int id)
        {
            return _ctx.Blogs
                .Include("BlogCategory")
                .Include("BlogAuthor")
                .Where(b => b.Id == id)
                .SingleOrDefault();
        }

        public bool DeleteBlog(int id)
        {
            try
            {
                var entity = _ctx.Blogs.Find(id);
                if (entity != null)
                {
                    _ctx.Blogs.Remove(entity);
                    return true;
                }
            }
            catch
            {
                //ToDo: Logging
            }

            return false;
        }

        public bool Update(Blog originalBlog, Blog updatedBlog)
        {
            _ctx.Entry(originalBlog).CurrentValues.SetValues(updatedBlog);
            //To update child entites in Course entity
            originalBlog.BlogCategory = updatedBlog.BlogCategory;
            originalBlog.BlogAuthor = updatedBlog.BlogAuthor;

            return true;
        }

        public bool Insert(Blog blog)
        {
            try
            {
                _ctx.Blogs.Add(blog);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}