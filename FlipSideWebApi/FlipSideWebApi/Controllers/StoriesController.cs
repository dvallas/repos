using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FlipSideDataAccess;
using Models;

namespace FlipSideWebApi.Controllers
{
    public class StoriesController : ApiController
    {
        protected StoriesController()
        {
        }

        // GET: api/Stories
        public IEnumerable<Story> Get()
        {
            return new DA().ReadStories(DateTime.Today);
        }

        // GET: api/Stories/5
        public Story Get(int id)
        {
            return new DA().ReadStory(id);
        }

        // POST: api/Stories
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Stories/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Stories/5
        public void Delete(int id)
        {
        }
    }
}
