using System;
using System.Collections.Generic;

namespace bandienthoai.Models.DAO.Objects
{
    public class UserArticleRatings
    {
        //hold all rating data and similar score for each user
        public int UserID { get; set; }

        public int[] ArticleRatings { get; set; }

        public double Score { get; set; }

        public UserArticleRatings(int userId, int articlesCount)
        {
            UserID = userId;
            ArticleRatings = new int[articlesCount];
        }

    }
}
