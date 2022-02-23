using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Core
{
    public class FakeApiUser : IApplicationActor
    {
        public int Id => 2;
        public string Identity => "Fake Api User";

        public IEnumerable<int> AllowedUseCases => new List<int> { 3}; 
    }

    public class AdminApiUser : IApplicationActor
    {
        public int Id => 1;

        public string Identity => "Admin Api User";

        public IEnumerable<int> AllowedUseCases => new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31 };
    }

}
