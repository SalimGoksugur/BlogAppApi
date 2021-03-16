using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BlogAppApi.Core.Entities
{
    public class Category:BaseEntity
    {
        public Category()
        {
            Articles = new Collection <Article>();
        }
        public Category(int id,string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
