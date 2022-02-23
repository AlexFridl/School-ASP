using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{ 
    public class Comment : Entity
    {
        public string TextComment { get; set; }
       
        public int NewsId { get; set; }
        public int UserId { get; set; }


        public virtual News News { get; set; }
        public virtual User Users { get; set; }

    }
}
