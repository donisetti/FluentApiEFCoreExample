using System.Collections.Generic;

namespace FluentApiEFCoreExample.Entities
{
    public class Category : Entity
    {
        protected Category() { }
        public Category(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public IEnumerable<ArticleCategory> CategoryArticles { get; private set; }
    }
}
