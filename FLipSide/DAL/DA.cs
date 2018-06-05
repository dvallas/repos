
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
//using Dapper;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using FlipSideModels;
using FlipSideNet.DAL;
using System.Data.Entity.Core.Common;
using System.Threading.Tasks;

namespace FlipSideDataAccess
{

    public class DA
    {
        public readonly FlipSideDataContext _context;

        public DA()
        {
            
            ;}
        public DA(FlipSideDataContext context)
        {
            this._context = context;
        }




        //public List<Story> ReadStories(DateTime date)
        //{
        //    return new Repository().Query<Story>
        //
        // ("SELECT * FROM story order by DateRan");
        //}

        //public Story ReadStory(int id)
        //{
        //    return new Repository().QueryFirstOrDefault<Story>(
        //        "SELECT * FROM story where id=" + id.ToString() + " order by DateRan");
        //}

        public async Task<int> WriteStory(Story story)
        {
            var r = new Repository();
            var sql = "INSERT INTO [dbo].[story]([dateRan], [slug], [summary], [byline], [lean], [link], [topic]) " +
                        $" VALUES('{story.dateran}','{story.slug}','{story.summary}','{story.byline}','{story.lean}','{story.link}', '{story.topic}', '{story.shouldrun}','{story.id}' )";

            Task<int> t=new Task<int>(() =>
            {
                return r.Query<string>(sql) ;
            });
            t.Start();
            return await t;

        }

    }

    class Repository
    {

        public DbContext CreateConnection()
        {
            return new FlipSideNet.DAL.FlipSideDataContext()._Context;
        }

        public DisplayPage GetDisplayPage()
        {
            {
                var sc = new FlipSideDataContext();
                DisplayPage dp;
                //dp=sc.DisplayPage.SqlQuery("sp_getDisplay");

                return  new DisplayPage();
            }
        }


        //public T QueryFirstOrDefault<T>(string sql, object parameters = null)
        //{
        //    using (var connection = CreateConnection())
        //    {
        //        var cs = ConfigurationManager.ConnectionStrings[0].ConnectionString;
        //        return connection.QueryFirstOrDefault<T>(sql, parameters);
        //    }
        //}

        //public List<T> Query<T>(string sql, object parameters = null)
        //{
        //    using (var connection = CreateConnection())
        //    {
        //        if (sql != null) return connection.Query<T>(sql, parameters).ToList();
        //        return new List<T>();
        //    }
        //}

        //protected int Execute(string sql, object parameters = null)
        //{
        //    using (var connection = CreateConnection())
        //    {
        //        return connection.Execute(sql, parameters);
        //    }
        //}

        internal int Query<T>(string sql)
        {
            var c = CreateConnection();
            c.Database.ExecuteSqlCommand(sql);
            return 1;
        }
    }

}

