using BookStore.Application;
using BookStore.DataAccess;
using BookStore.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Implementation.Logging
{
    public class DatabaseUseCaseLoger : IUseCaseLogger
    {
        private readonly BookStoreContext _context;

        public DatabaseUseCaseLoger(BookStoreContext context)
        {
            _context = context;
        }

        public void Log(IUseCase useCase, IApplicationActor actor, object useCaseData)
        {
            _context.UseCaseLogs.Add(new UseCaseLog
            {
                Actor = actor.Identity,
                Data = JsonConvert.SerializeObject(useCaseData),
                Date = DateTime.Now,
                UseCaseName = useCase.Name
            });
            _context.SaveChanges();
        }
    }
}
