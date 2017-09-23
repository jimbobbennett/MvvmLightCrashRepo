using System.Collections.Generic;
using System.Threading.Tasks;
using Countr.Core.Models;
using Countr.Core.Repositories;
using GalaSoft.MvvmLight.Messaging;

namespace Countr.Core.Services
{
    public class CountersService : ICountersService
    {
        readonly ICountersRepository repository;
        readonly IMessenger messenger;

        public CountersService(ICountersRepository repository,
                               IMessenger messenger)
        {
            this.messenger = messenger;
            this.repository = repository;
        }

        public async Task<Counter> AddNewCounter(string name)
        {
            var counter = new Counter { Name = name };
            await repository.Save(counter).ConfigureAwait(false);
            messenger.Send(new CountersChangedMessage());
            return counter;
        }

        public Task<List<Counter>> GetAllCounters()
        {
            return repository.GetAll();
        }

        public async Task DeleteCounter(Counter counter)
        {
            await repository.Delete(counter).ConfigureAwait(false);
            messenger.Send(new CountersChangedMessage());
        }

        public Task IncrementCounter(Counter counter)
        {
            counter.Count += 1;
            return repository.Save(counter);
        }
    }
}