using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Picture : Entity
    {
        
        public string Src { get; set; }
        public string Alt { get; set; }

        public int NewsId { get; set; }

        public virtual News News { get; set; }
    }
}
