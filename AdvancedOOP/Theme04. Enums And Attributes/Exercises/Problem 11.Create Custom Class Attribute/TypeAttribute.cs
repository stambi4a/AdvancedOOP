namespace Problem_11.Create_Custom_Class_Attribute
{
    using System;
    using System.Collections.Generic;

    [AttributeUsage(AttributeTargets.Class)]
    public class TypeAttribute : Attribute
    {
        public TypeAttribute(string author, string revision, string description, params string[] reviewers)
        {
            this.Author = author;
            this.Revision = revision;
            this.Description = description;
            this.AddReviewers(reviewers);
        }

        public string Author { get; set; }

        public string Revision { get; set; }

        public string Description { get; set; }

        public List<string> Reviewers { get; set; }

        private void AddReviewers(params string[] reviewers)
        {
            this.Reviewers = new List<string>();
            foreach (var reviewer in reviewers)
            {
                this.Reviewers.Add(reviewer);
            }
        }
    }
}
