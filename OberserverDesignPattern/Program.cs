using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OberserverDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ISubject controladorEmail = new ControladorEmail();

            UsuarioA usuarioA = new UsuarioA();
            UsuarioB usuarioB = new UsuarioB();
            UsuarioC usuarioC = new UsuarioC();

            controladorEmail.Registrar(usuarioA);
            controladorEmail.Registrar(usuarioB);
            controladorEmail.Registrar(usuarioC);

            Console.WriteLine("Os usuários A, B e C cadastraram-se para receber as promoções \n");
            Console.WriteLine("Enviando os emails para os usuários cadastrados. \n");

            controladorEmail.EnviarEmail();

            Console.WriteLine("\n O usuário A resolveu cancelar a assinatura e não irar receber mais emails. \n");
            controladorEmail.Remover(usuarioA);

            Console.WriteLine("Enviando emails para os usuários cadastrados. \n");
            controladorEmail.EnviarEmail();

            Console.ReadKey();
        }
    }

    public interface ISubject
    {
        void Registrar(IObserver observer);
        void Remover(IObserver observer);
        void EnviarEmail();
    }

    public interface IObserver
    {
        void ReceberEmail();
    }

    public class ControladorEmail : ISubject
    {
        private readonly List<IObserver> _usuarios;

        public ControladorEmail()
        {
            _usuarios = new List<IObserver>();
        }

        public void Registrar(IObserver observer)
        {
            _usuarios.Add(observer);
        }

        public void Remover(IObserver observer)
        {
            _usuarios.Remove(observer);
        }

        public void EnviarEmail()
        {
            foreach (var usuario in _usuarios)
            {
                usuario.ReceberEmail();
            }
        }
    }

    public class UsuarioA : IObserver
    {
        public void ReceberEmail()
        {
            Console.WriteLine("Email recebido pelo usuário A");

            // Receber email lógica
        }
    }

    public class UsuarioB : IObserver
    {
        public void ReceberEmail()
        {
            Console.WriteLine("Email recebido pelo usuário B");
        }
    }

    public class UsuarioC : IObserver
    {
        public void ReceberEmail()
        {
            Console.WriteLine("Email recebido pelo usuário C");
        }
    }
}
