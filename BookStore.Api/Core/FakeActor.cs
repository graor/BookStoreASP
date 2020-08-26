using BookStore.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Api.Core
{
    public class FakeActor : IApplicationActor
    {
        public int Id => 1;

        public string Identity => "TestApiActor";

        public IEnumerable<int> AllowedUseCases => Enumerable.Range(1, 100);
    }
}
