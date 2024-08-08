namespace bandienthoai.Models.DAO.Objects
{
    public class Suggestion
    {
        //hold all suggestion after calculate as ouput data
        public int UserID { get; set; }

        public long ArticleID { get; set; }
        
        public double Rating { get; set; }//mean similar score to compare

        public Suggestion(int userId, long articleId, double rating)
        {
            UserID = userId;
            ArticleID = articleId;
            Rating = rating;
        }
    }
}
