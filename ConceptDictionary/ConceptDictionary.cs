using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ConceptDictionary
{
    public class ConceptDictionary
    {
        private int ConceptID;
        private string title;
        private string body;
        private string conceptImage;
        private string ConceptLink;
        private int CategoryID;

        public ConceptDictionary(string title, string body, string conceptImage, string conceptLink)
        {
            this.title = title;
            this.body = body;
            this.conceptImage = conceptImage;
            ConceptLink = conceptLink;
        }

        public ConceptDictionary(int conceptID, string title, string body, string conceptImage, string conceptLink, int categoryID)
        {
            ConceptID = conceptID;
            this.title = title;
            this.body = body;
            this.conceptImage = conceptImage;
            ConceptLink = conceptLink;
            CategoryID = categoryID;
        }

        public string Title { get => title; set => title = value; }
        public string Body { get => body; set => body = value; }
        public string ConceptImage { get => conceptImage; set => conceptImage = value; }
        public string ConceptLink1 { get => ConceptLink; set => ConceptLink = value; }
        public int CategoryID1 { get => CategoryID; set => CategoryID = value; }
        public int ConceptID1 { get => ConceptID; set => ConceptID = value; }
    }
}
