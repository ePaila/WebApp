using ePaila.Data.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ePaila.ViewModel;
using System.Data.Entity.Core.Objects;

namespace ePaila.Data.Repo
{
    public class ArticleRepository
    {
        ePailaEntities _db;

        public ArticleRepository(ePailaEntities db)
        {
            _db = db;
        }

        public List<ViewModel.Article> Get()
        {
            DateTime dateMargin = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            List<ViewModel.Article> results = new List<ViewModel.Article>();
            try
            {
               results = _db.Articles
                .Where(x => !x.IsDeleted
                    && x.PostedDate >= dateMargin
                    )
                .Select(y => new ViewModel.Article()
                {
                    ArticleID = y.ID,
                    Title = y.Title,
                    Body = y.Body,
                    PostedDate = y.PostedDate.Value,
                    IsVisible = y.IsVisible
                })
            .ToList<ViewModel.Article>();
                if(results.Count==0)
                    results = _db.Articles                
                .Select(y => new ViewModel.Article()
                {
                    ArticleID = y.ID,
                    Title = y.Title,
                    Body = y.Body,
                    PostedDate = y.PostedDate.Value,
                    IsVisible = y.IsVisible
                })
                .OrderByDescending(z=> z.PostedDate)
                .Take(3)
            .ToList<ViewModel.Article>();
            }
            catch (Exception ex)
            {

                throw;
            }
            
            return results;
        }

        public ViewModel.Article Get(int id)
        {
            return _db.Articles
                .Where(x => !x.IsDeleted & x.ID == id)
                .Select(y => new ViewModel.Article()
            {
                ArticleID = y.ID,
                Title = y.Title,
                Body = y.Body,
                PostedDate = y.PostedDate.Value,
                IsVisible = y.IsVisible
            }
            ).FirstOrDefault();
        }

        public List<ViewModel.Article> Get(DateTime day)
        {            
            List<ViewModel.Article> results = new List<ViewModel.Article>();
            try
            {
                results = _db.Articles
                 .Where(x => !x.IsDeleted
                 
                     && EntityFunctions.TruncateTime(x.PostedDate) == EntityFunctions.TruncateTime(day)
                     )
                 .Select(y => new ViewModel.Article()
                 {
                     ArticleID = y.ID,
                     Title = y.Title,
                     Body = y.Body,
                     PostedDate = y.PostedDate.Value,
                     IsVisible = y.IsVisible
                 })
             .ToList<ViewModel.Article>();
            }
            catch (Exception ex)
            {

                throw;
            }

            return results;
        }

    }
}
