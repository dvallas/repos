using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlipSideDashboard.Models
{
    public class Story
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public DateTime dateRan { get; set; }
        public string Summary { get; set; }
        public string Byline { get; set; }
        public string Lean { get; set; }
    }
}
