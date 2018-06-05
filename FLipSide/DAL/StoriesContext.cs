using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using FlipSideModels;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;
using MySql.Data.Entity;

namespace FlipSideNet.DAL
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class FlipSideDataContext : DbContext
    {
        //DbConnection _db1=new EntityConnection("server = localhost:3306; Initial Catalog = flipside; uid=dvallas; pwd=Drink7up;");
        public DbContext _Context
        {
            get { return new DbContext("FlipSideDataContext"); }
        }

        public FlipSideDataContext() :  base("FlipSideDataContext")
        {
        }
        public DbSet<TrendingTopic> TrendingTopics { get; set; }
        public DbSet<Story> Story { get; set; }
        public DbSet<Topics> Topics { get; set; }
        public DbSet<DisplayPage> DisplayPage { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        

    }
}