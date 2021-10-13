using System;
using System.Collections.Generic;
using System.Text;

namespace ConceptDictionary
{
    public class Category
    {
        private int categoryID;
        private string categoryName;

        public Category(int categoryID, string categoryName)
        {
            this.categoryID = categoryID;
            this.categoryName = categoryName;
        }

        public int CategoryID { get => categoryID; set => categoryID = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }
    }
}
