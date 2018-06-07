
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
        private DbContext _Context;

        public DA(FlipSideDataContext context)
        {
            this._context = context;
        }

        public DA(DbContext context)
        {
            _Context = context;
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
            try
            {
                var r = new Repository();
                var sql = "INSERT INTO flipside.Story (dateRan, slug, summary, byline, lean, link, topic, shouldrun, is_active) " +
                            $" VALUES ('{story.dateran.Date:yyyy-MM-dd}','{story.slug}','{story.summary}','{story.byline}'," +
                          $"'{story.lean.ToString()}','{story.link}', '{story.topic}', '{story.shouldrun.Date:yyyy-MM-dd}', '{story.is_active.ToString()}' )";

                Log.Info("SQL: " + sql);
                Task<int> t=new Task<int>(() =>
                {
                    return r.Query<string>(sql) ;
                });
                t.Start();
                return await t;

            }
            catch (Exception e)
            {
                Log.Error("WriteStory failed: " + e.Message + e.InnerException);
                return 0;
            }

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
            try
            {
                Log.Info("Starting query");
                var c = CreateConnection();
                var a = c.Database.ExecuteSqlCommand(sql);
                Log.Info("query returned " + a.ToString());
                return a;

            }
            catch (Exception e)
            {
                Log.Info(e.Message + e.InnerException);
                Console.WriteLine(e);
                return 0;
            }

        }
    }

}

