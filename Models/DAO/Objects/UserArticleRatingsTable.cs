using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bandienthoai.Models.DAO.Objects
{
    //hold matrix use to calculate
    public class UserArticleRatingsTable
    {
        //rating data
        public List<UserArticleRatings> Users { get; set; }
        //user index in matrix
        public List<int> UserIndexToID { get; set; }
        //article index in matrix
        public List<long> ArticleIndexToID { get; set; }

        public UserArticleRatingsTable()
        {
            Users = new List<UserArticleRatings>();
            UserIndexToID = new List<int>();
            ArticleIndexToID = new List<long>();
        }
        
        
    }
}
