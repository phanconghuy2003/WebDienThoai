using System;

namespace bandienthoai.Models.DAO.Objects
{
    //hold all data from rating table in db, can extend to hold more data than rating
    //articleID mean itemID and item use star 
    //but it can be something more like upvote, downvote... and some another score unit
    public class UserAction
    {

        public int UserID { get; set; }

        public long ArticleID { get; set; }

        public int Star{get; set;}

        public UserAction( int userid, long articleid,int star)
        {

            UserID = userid;

            ArticleID = articleid;

            Star = star;
    }

    }
}
