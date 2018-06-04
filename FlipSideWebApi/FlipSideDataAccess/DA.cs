
using System;
using System.Collections.Generic;
using Models;

namespace FlipSideDataAccess
{
    
    public class DA
    {

        public int WriteStory(Story story)
        {
            return 1;
        }

        public List<Story> ReadStories(DateTime date)
        {
            return new BaseRepository().Query<Story>("SELECT * FROM story order by DateRan");
        }
        public Story ReadStory(int id)
        {
            return new BaseRepository().QueryFirstOrDefault<Story>("SELECT * FROM story where id=" + id.ToString() + " order by DateRan");
        }
    }
}