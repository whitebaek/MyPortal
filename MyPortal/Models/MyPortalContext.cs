using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyPortal.Models
{
    public class MyPortalContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MyPortalContext() : base("name=MyPortalContext")
        {
            //http://stackoverflow.com/questions/3372895/datacontractserializer-error-using-entity-framework-4-0-with-wcf-4-0
            base.Configuration.ProxyCreationEnabled = false;
        }


        public System.Data.Entity.DbSet<MyPortal.Models.Article> Articles { get; set; }
        public System.Data.Entity.DbSet<MyPortal.Models.Comment> Comments { get; set; }
        public System.Data.Entity.DbSet<MyPortal.Models.EventModel> EventModels { get; set; }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //Configure domain classes using Fluent API here
        //    base.OnModelCreating(modelBuilder);

        //    //one-to-many 
        //    modelBuilder.Entity<Comment>().HasRequired<Article>(c => c.Article)
        //    .WithMany(a => a.Comments).HasForeignKey(c => c.ArticleId);
        //}
    
    }
}
