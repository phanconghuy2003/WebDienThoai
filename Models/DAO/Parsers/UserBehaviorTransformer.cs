using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bandienthoai.Models.DAO.Objects;

namespace bandienthoai.Models.DAO.Parsers
{
    public class UserBehaviorTransformer
    {
        //Transform data to matrix use to calculate
        private UserBehaviorDatabase db;

        public UserBehaviorTransformer(UserBehaviorDatabase database)
        {
            db = database;
        }
        
        public UserArticleRatingsTable GetUserArticleRatingsTable()
        {
            UserArticleRatingsTable table = new UserArticleRatingsTable();
            db.Users.Sort();
            table.UserIndexToID = db.Users.Distinct().ToList();
            db.Articles.Sort();
            table.ArticleIndexToID = db.Articles.Distinct().ToList();

            foreach (int userId in table.UserIndexToID)
            {
                table.Users.Add(new UserArticleRatings(userId, table.ArticleIndexToID.Count));
            }

            var userArticleRatingGroup = db.UserActions
                .GroupBy(x => new { x.UserID, x.ArticleID })
                .Select(g => new { g.Key.UserID, g.Key.ArticleID, Rating = db.UserActions.Where(i => i.UserID == g.Key.UserID && i.ArticleID ==g.Key.ArticleID).Select(r => r.Star).First() })
                .ToList();

            foreach (var userAction in userArticleRatingGroup)
            {
                int userIndex = table.UserIndexToID.IndexOf(userAction.UserID);
                int articleIndex = table.ArticleIndexToID.IndexOf(userAction.ArticleID);

                table.Users[userIndex].ArticleRatings[articleIndex] = userAction.Rating;
            }

            return table;
        }


    }
}
