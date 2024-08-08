using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bandienthoai.Models.DAO.Objects;
using bandienthoai.Models.EF;

namespace bandienthoai.Models.DAO.Parsers
{
    public class UserBehaviorDatabaseParser
    {
        //get all data from db and parse to holder
        public UserBehaviorDatabaseParser()
        {

        }

        
        public UserBehaviorDatabase LoadUserBehaviorDatabase()
        {
            UserBehaviorDatabase db = new UserBehaviorDatabase();

            QlBanHangDbContext dbsql = new QlBanHangDbContext();
            
            List<int> userIDs = (from Rating in dbsql.Ratings select Rating.IDUser).ToList();
            List<long> articleIDs = (from Rating in dbsql.Ratings select Rating.IDItem).ToList();
            List<int> stars = (from Rating in dbsql.Ratings select Rating.Star).ToList();


            for (int i = 0; i < articleIDs.Count; i++)
            {

                    db.Articles.Add(articleIDs[i]);

            }

            for (int i = 0; i < userIDs.Count ; i++)
            {

                db.Users.Add(userIDs[i]);

            }

            foreach (var rating in dbsql.Ratings)
            {
                db.UserActions.Add(new UserAction(rating.IDUser,rating.IDItem,rating.Star));
            }

            return db;
        }
    }
}
