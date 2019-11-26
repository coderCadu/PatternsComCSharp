using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverInterfacesDotNet
{
    public class Disposer : IDisposable
    {
        private List<IObserver<Email>> _users;
        private IObserver<Email> _user;

        public Disposer(List<IObserver<Email>> users, IObserver<Email> user)
        {
            _users = users;
            _user = user;
        }

        public void Dispose()
        {
            if (_users.Contains(_user))
                _users.Remove(_user);
        }
    }
}
