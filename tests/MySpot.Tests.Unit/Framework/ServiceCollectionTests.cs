using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySpot.Tests.Unit.Framework
{
    public class ServiceCollectionTests
    {
        [Fact]
        public void test()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IMessenger, Messenger>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var messenger = serviceProvider.GetService<IMessenger>();
        }
        private interface IMessenger
        {
            void Send();
        }

        private class Messenger : IMessenger
        {
            private readonly Guid _id = Guid.NewGuid();
            public void Send() => Console.Out.WriteLine($"sending a message ... {_id}");
        }
    }
}
