using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.SqlClient;
using FlipSideDataAccess;

namespace FlipSideModels
{
    public class DisplayPage
    {
        [Key]
        public string Headline { get; set; }
        public IEnumerable<Story> LeftStory { get; set; }
        public IEnumerable<Story> RightStory { get; set; }


    }
}
