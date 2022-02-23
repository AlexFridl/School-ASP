using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Text : Entity
    {
        public string TextNews { get; set; }

        public int NewsId { get; set; }

        public virtual News News { get; set; }
    }
}
