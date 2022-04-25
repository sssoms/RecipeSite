using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSiteLibrary
{
    [Serializable]
    public class Review
    {
        private int userID;
        private string title;
        private string text;
        private int starRating;

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public int StarRating
        {
            get { return starRating; }
            set { starRating = value; }
        }

        public Review()
        {

        }
    }
}
