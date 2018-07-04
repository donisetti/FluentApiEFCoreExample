using System.Collections.Generic;

namespace FluentApiEFCoreExample.Entities
{
    public class Article : Entity
    {
        protected Article() { }
        public Article(string title, string body, User user)
        {
            Title = title;
            Body = body;
            User = user;
        }

        public string Title { get; private set; }
        public string Body { get; private set; }

        public User User { get; private set; }
        public IEnumerable<ArticleCategory> CategoryArticles { get; private set; }
    }
}
