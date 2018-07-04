using System.Collections.Generic;

namespace FluentApiEFCoreExample.Entities
{
    public class User : Entity
    {
        protected User() {}
        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }

        public IEnumerable<Article> Articles { get; }
    }
}
