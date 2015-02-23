using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVPWebApiRESTfulJSON.Models;
using MVPWebApiRESTfulJSON.DAL;
using MVPWebApiRESTfulJSON.Entity;

namespace MVPWebApiRESTfulJSON.Controllers
{
    public class BlogController : ApiController
    {
        private ModelFactory _modelFactory;
        protected ModelFactory TheModelFactory
        {
            get
            {
                if (_modelFactory == null)
                {
                    _modelFactory = new ModelFactory();
                }
                return _modelFactory;
            }
        }

        public Object Get()
        {
            IQueryable<Blog> query;
            query = TheModelFactory.GetAllBlogs().OrderBy(c => c.Title);

            var results = query
                          .ToList()
                          .Select(s => TheModelFactory.Create(s));

            return new
            {
                Results = results
            };
        }

        // GET api/blog/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var blog = TheModelFactory.GetBlog(id);
                if (blog != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, TheModelFactory.Create(blog));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // POST api/blog
        public HttpResponseMessage Post([FromBody]BlogModel blogModel)
        {
            try
            {
                var entity = TheModelFactory.Parse(blogModel);

                if (entity == null) 
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read from body.");

                if (TheModelFactory.Insert(entity) && TheModelFactory.SaveAll())
                    return Request.CreateResponse(HttpStatusCode.Created, TheModelFactory.Create(entity));
                else
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not save to the database.");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT api/blog/5
        public HttpResponseMessage Put(int id, [FromBody]BlogModel blogModel)
        {
            try
            {
                var updatedBlog = TheModelFactory.Parse(blogModel);

                if (updatedBlog == null) 
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read from body.");

                var originalBlog = TheModelFactory.GetBlog(id);

                if (originalBlog == null || originalBlog.Id != id)
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, "Course is not found");
                }
                else
                {
                    updatedBlog.Id = id;
                }

                if (TheModelFactory.Update(originalBlog, updatedBlog) && TheModelFactory.SaveAll())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, TheModelFactory.Create(updatedBlog));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE api/blog/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var blog = TheModelFactory.GetBlog(id);
                if (blog == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound);

                if (TheModelFactory.DeleteBlog(id) && TheModelFactory.SaveAll())
                { 
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
