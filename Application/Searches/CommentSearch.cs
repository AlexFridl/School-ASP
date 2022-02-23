using Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class CommentSearch : PagedSearch
    {
        public int UserId { get; set; }
    }
}
