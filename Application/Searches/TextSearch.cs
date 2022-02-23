using Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class TextSearch : PagedSearch
    {
        public int NewsId { get; set; }
    }
}
