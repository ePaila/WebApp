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

        /// <summary>
        /// Get all articles
        /// </summary>
        /// <returns></returns>
        public List<ViewModel.Article> GetAll()
        {
            List<ViewModel.Article> results = new List<ViewModel.Article>();
            try
            {
                results = _db.Articles
                 .Where(x => !x.IsDeleted)
                 .OrderByDescending(z => z.PostedDate)
                 .Select(y => new ViewModel.Article()
                 {
                     ArticleID = y.ID,
                     Title = y.Title,
                     Body = y.Body,
                     PostedDate = y.PostedDate.Value,
                     IsVisible = y.IsVisible,
                     Favorite = y.Favorites.Count
                 })
             .ToList<ViewModel.Article>();
            }
            catch (Exception ex)
            {

                throw;
            }

            return results;
        }

        /// <summary>
        /// Get all articles posted on particular month
        /// </summary>
        /// <returns></returns>
        public List<ViewModel.Article> Get()
        {
            List<ViewModel.Article> results = new List<ViewModel.Article>();
            try
            {
                results = _db.Articles
                 .Where(x => !x.IsDeleted)
                 .Select(y => new ViewModel.Article()
                 {
                     ArticleID = y.ID,
                     Title = y.Title,
                     Body = y.Body,
                     PostedDate = y.PostedDate.Value,
                     IsVisible = y.IsVisible,
                     Favorite = y.Favorites.Count
                 })
                 .OrderByDescending(z => z.PostedDate)
                 .Take(5)
             .ToList<ViewModel.Article>();

            }
            catch (Exception ex)
            {

                throw;
            }

            return results;
        }

        /// <summary>
        /// Get Article by article id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
                    IsVisible = y.IsVisible,
                    Favorite = y.Favorites.Count
                }
            ).FirstOrDefault();
        }

        /// <summary>
        /// Get all articles posted on particular day
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
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
                     IsVisible = y.IsVisible,
                     Favorite = y.Favorites.Count
                 })
             .ToList<ViewModel.Article>();
            }
            catch (Exception ex)
            {

                throw;
            }

            return results;
        }

        public bool Favorite(int article_id, string info)
        {
            Favorite obj = new Data.Favorite() { DateTime = DateTime.Now, Article_ID = article_id, UserIP = info };
            try
            {
                if (!_db.Favorites.Any(x => x.Article_ID == article_id & x.UserIP == info))
                    _db.Favorites.Add(obj);
               
            }
            catch (Exception ex)
            {

                throw;
            }
            return _db.SaveChanges() > 0;
        }

        public int Favorite(int article_id)
        {
            int count = 0;
            try
            {
                count = _db.Favorites.Where(x => x.Article_ID == article_id).Count();
            }
            catch (Exception ex)
            {

                throw;
            }

            return count;
        }
    }
}
