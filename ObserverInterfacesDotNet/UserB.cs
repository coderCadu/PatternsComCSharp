using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverInterfacesDotNet
{
    public class UserB : IObserver<Email>
    {
        private IDisposable _disposer;

        public UserB(IObservable<Email> emailController)
        {
            _disposer = emailController.Subscribe(this);
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception exception)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Email value)
        {
            Console.WriteLine($"{value.Description} B");
        }

        public void Dispose()
        {
            _disposer.Dispose();
        }
    }
}
