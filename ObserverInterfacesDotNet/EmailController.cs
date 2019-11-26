using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverInterfacesDotNet
{
    public class EmailController : IObservable<Email>
    {
        public List<IObserver<Email>> _users;
        public Email _email;

        public EmailController(Email email)
        {
            _users = new List<IObserver<Email>>();
            _email = email;
        }

        public IDisposable Subscribe(IObserver<Email> usuario)
        {
            if (!_users.Contains(usuario))
                _users.Add(usuario);

            return new Disposer(_users, usuario);
        }

        public void SendEmail()
        {
            _email.Description = "Email enviado para o usuário";

            foreach (IObserver<Email> usuario in _users)
            {
                usuario.OnNext(_email);
            }
        }
    }
}
