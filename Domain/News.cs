using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class News : Entity
    {
        
        public string TitleNews { get; set; }
        public string Subtitle { get; set; }
        public int CategoryId { get; set; }
        
        public virtual ICollection<Text> Texts { get; set; } = new HashSet<Text>();
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        public virtual ICollection<Picture> Pictures { get; set; } = new HashSet<Picture>();

        public virtual Category Category { get; set; }
        //public string Name { get; set; }
    }
}
