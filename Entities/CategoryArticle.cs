namespace FluentApiEFCoreExample.Entities
{
    public class ArticleCategory : Entity
    {
        protected ArticleCategory() { }
        public ArticleCategory(Category category, Article article)
        {
            Category = category;
            Article = article;
        }

        public Category Category { get; private set; }
        public Article Article { get; private set; }
    }
}
