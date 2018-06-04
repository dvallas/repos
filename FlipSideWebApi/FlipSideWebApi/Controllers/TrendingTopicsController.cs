using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FlipSideWebApi.Models;

namespace FlipSideWebApi.Controllers
{
    public class TrendingTopicsController : ApiController
    {
        TrendingTopic[] topics = new TrendingTopic[]
  {
            new TrendingTopic { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new TrendingTopic { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new TrendingTopic { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
  };

        public IEnumerable<TrendingTopic> GetAllTopics()
        {
            return topics;
        }

        public IHttpActionResult GetTopic(int id)
        {
            var topic = topics.FirstOrDefault((p) => p.Id == id);
            if (topic == null)
            {
                return NotFound();
            }
            return Ok(topic);
        }
    }
}
