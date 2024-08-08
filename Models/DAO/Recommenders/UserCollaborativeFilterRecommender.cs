using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bandienthoai.Models.DAO.Comparers;

using bandienthoai.Models.DAO.Objects;
using bandienthoai.Models.DAO.Parsers;

namespace bandienthoai.Models.DAO.Recommenders
{
    public class UserCollaborativeFilterRecommender 
    {
        private CorrelationUserComparer comparer;
        private UserArticleRatingsTable ratings;

        private int neighborCount;


        public UserCollaborativeFilterRecommender( int numberOfNeighbors)
        {
            comparer = new CorrelationUserComparer();
            neighborCount = numberOfNeighbors;
        }
        //get data from db and tranform it to matrix use to calculate
        public void Train(UserBehaviorDatabase db)
        {
            UserBehaviorTransformer ubt = new UserBehaviorTransformer(db);
            ratings = ubt.GetUserArticleRatingsTable();

        }
        //main function call everything to make output
        public List<Suggestion> GetSuggestions(int userId, int numSuggestions)
        {
            //get index of user from userid in matrix
            int userIndex = ratings.UserIndexToID.IndexOf(userId);
            //get all rating data for this user
            UserArticleRatings user = ratings.Users[userIndex];
            List<Suggestion> suggestions = new List<Suggestion>();
            //main calculate to get similar users(get 50 neighbors)
            var neighbors = GetNearestNeighbors(user, neighborCount);
            //loop through every articles in matrix and get recommend articles base on returned neighbors
            for (int i = 0; i < ratings.ArticleIndexToID.Count; i++)
            {
                //if the user has not rated the current article yet
                if (user.ArticleRatings[i] == 0)
                {
                    double score = 0.0;
                    int count = 0;
                    //for each neighbors
                    for (int u = 0; u < neighbors.Count; u++)
                    {
                        //if neighbor has rated the current article
                        if (neighbors[u].ArticleRatings[i] != 0)
                        {
                            //calculate score base on neighbors rating score
                            score += neighbors[u].ArticleRatings[i] - ((u + 1.0) / 100.0);
                            count++;
                        }
                    }
                    //if have neighbors rated the current article
                    if (count > 0)
                    {
                        //calculate average
                        score /= count;
                    }

                    suggestions.Add(new Suggestion(userId, ratings.ArticleIndexToID[i], score));
                }
            }
            //sort to pick highest score in list
            suggestions.Sort((c, n) => n.Rating.CompareTo(c.Rating));

            return suggestions.Take(numSuggestions).ToList();
        }

        private List<UserArticleRatings> GetNearestNeighbors(UserArticleRatings user, int numUsers)
        {
            List<UserArticleRatings> neighbors = new List<UserArticleRatings>();
            //for each user in table(matrix) compare to another user
            for (int i = 0; i < ratings.Users.Count; i++)
            {
                //it can't compare with itself
                if (ratings.Users[i].UserID == user.UserID)
                {
                    //set it to bottom of list
                    ratings.Users[i].Score = double.NegativeInfinity;
                }
                else
                {
                    //calculate and set similar score for each user
                    ratings.Users[i].Score = comparer.CompareVectors(ratings.Users[i].ArticleRatings, user.ArticleRatings);
                }
            }
            //sort high to low score
            var similarUsers = ratings.Users.OrderByDescending(x => x.Score);

            return similarUsers.Take(numUsers).ToList();
        }

        
    }
}
