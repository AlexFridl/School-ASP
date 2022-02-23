using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Category : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<News> Newses { get; set; } = new HashSet<News>();
       // public string TitleNews { get; set; }
        //public string Subtitle { get; set; }
    }
}
