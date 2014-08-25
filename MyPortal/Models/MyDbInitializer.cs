using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyPortal.Models
{
    //public class MyDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    public class MyDbInitializer : DropCreateDatabaseAlways<MyPortalContext>
    {
        protected override void Seed(MyPortalContext context)
        {
            InitializeIdentityForEF(context);
            base.Seed(context);
        }

        private void InitializeIdentityForEF(MyPortalContext context)
        {

            new List<Article>
            {
                new Article { Title="Title1", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title2", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title3", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title4", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title5", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title6", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title7", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title8", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title9", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title10", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title2", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title3", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title4", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title5", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title6", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title7", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title8", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title9", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title10", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title2", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title3", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title4", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title5", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title6", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title7", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title8", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title9", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title10", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title2", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title3", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title4", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title5", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title6", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title7", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title8", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title9", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title10", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now },
                new Article { Title="Title11", UserId=1, Content="Contents3", Location="", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now }

            }.ForEach(a => context.Articles.Add(a));

            new List<Comment>
            {
                new Comment { ArticleId = 1, Content="jfklsdjklfjsdklajflasd", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now, UserId=1 },
                new Comment { ArticleId = 1, Content="dfkjsdkljflskadjflkasd", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now, UserId=1 },
                new Comment { ArticleId = 1, Content="kfjsdkl;jflasdk", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now, UserId=1 },
                new Comment { ArticleId = 1, Content="fksdajfklsdajlkfasd", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now, UserId=1 },
                new Comment { ArticleId = 1, Content="dfkjsdaklfjsdla", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now, UserId=1 },
                new Comment { ArticleId = 1, Content="dsljfk;lasdjkflasdj", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now, UserId=1 },
                new Comment { ArticleId = 2, Content="Contents3", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now, UserId=1 },
                new Comment { ArticleId = 2, Content="Contents3", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now, UserId=1 },
                new Comment { ArticleId = 2, Content="Contents3", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now, UserId=1 },
                new Comment { ArticleId = 2, Content="Contents3", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now, UserId=1 },
                new Comment { ArticleId = 2, Content="Contents3", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now, UserId=1 },
                new Comment { ArticleId = 1, Content="Contents3", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now, UserId=1 },
                new Comment { ArticleId = 1, Content="Contents3", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now, UserId=1 },
                new Comment { ArticleId = 1, Content="Contents3", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now, UserId=1 },
                new Comment { ArticleId = 1, Content="Contents3", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now, UserId=1 },
                new Comment { ArticleId = 1, Content="Contents3", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now, UserId=1 },
                new Comment { ArticleId = 2, Content="Contents3", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now, UserId=1 },
                new Comment { ArticleId = 1, Content="Contents3", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now, UserId=1 },
                new Comment { ArticleId = 1, Content="Contents3", CreatedDate=DateTime.Now, UpdatedDate= DateTime.Now, UserId=1 }
            }.ForEach(a => context.Comments.Add(a));

            new List<EventModel>
            {
                new EventModel { Title="Title1", Detail="Contents1", StartDate=DateTime.Now.AddDays(-1), EndDate= DateTime.Now.AddDays(-1), Address="", Url=""}, 
                new EventModel { Title="Title2", Detail="Contents2", StartDate=DateTime.Now.AddDays(-2), EndDate= DateTime.Now.AddDays(0), Address="", Url=""},
                new EventModel { Title="Title3", Detail="Contents3", StartDate=DateTime.Now.AddDays(-3), EndDate= DateTime.Now.AddDays(-3), Address="", Url=""},
                new EventModel { Title="Title4", Detail="Contents4", StartDate=DateTime.Now.AddDays(-4), EndDate= DateTime.Now.AddDays(-4), Address="", Url=""},
                new EventModel { Title="Title5", Detail="Contents5", StartDate=DateTime.Now.AddDays(-4), EndDate= DateTime.Now.AddDays(-4), Address="", Url=""},
                new EventModel { Title="Title6", Detail="Contents6", StartDate=DateTime.Now.AddDays(-5), EndDate= DateTime.Now.AddDays(+1), Address="", Url=""}

            }.ForEach(e => context.EventModels.Add(e));



        }
    }
}