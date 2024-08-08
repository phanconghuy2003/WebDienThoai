using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using bandienthoai.Models.DAO.Objects;


namespace bandienthoai.Models.DAO.Parsers
{
    //hold all data in db
    public class UserBehaviorDatabase
    {
       
        public List<long> Articles { get; set; }

        public List<int> Users { get; set; }

        public List<UserAction> UserActions { get; set; }

        public UserBehaviorDatabase()
        {
            Articles = new List<long>();
            Users = new List<int>();
            UserActions = new List<UserAction>();
        }


    }
}
