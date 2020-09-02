using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.SqlClient;
using FlipSideDataAccess;

namespace FlipSideModels
{
    public class DisplayPage
    {
        [Key]
        public IEnumerable<StoryPair>StoryPairs { get; set; }

        //public IEnumerator<StoryPair> GetEnumerator()
        //{
        //    return Events().GetEnumerator();
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator();
        //}
    }

    public class StoryPair
    {
        [Key]
        public string Headline { get; set; }
        public IEnumerable<Story> LeftStory { get; set; }
        public IEnumerable<Story> RightStory { get; set; }

    }
}
