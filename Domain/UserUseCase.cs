using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class UserUseCase
    {
        public int Id { get; set; }
        public int UserCaseId { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
