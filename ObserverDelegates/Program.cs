using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            ControladorEmail controlador = new ControladorEmail();
            var usuarioA = new UsuarioA();
            var usuarioB = new UsuarioB();
            var usuarioC = new UsuarioC();

            Console.WriteLine("Os usuarios A, B e C cadastraram-se para receber as promoções. \n");

            usuarioA.Assinar(controlador);
            usuarioB.Assinar(controlador);
            usuarioC.Assinar(controlador);

            Console.WriteLine("Enviando os emails para os usuarios assinados.\n");

            controlador.EnviarEmail();

            Console.WriteLine("\n O usuário A resolveu cancelar a assinatura e não irar receber mais emails. \n");

            usuarioA.CancelarAssinatura(controlador);

            Console.WriteLine("Enviando emails para os usuários cadastrados. \n");
            controlador.EnviarEmail();

            Console.ReadKey();
        }
    }

    public class ControladorEmail
    {
        public Action ProcessarEmail;

        public void EnviarEmail()
        {
            ProcessarEmail();
        }
    }

    public class UsuarioA
    {
        public void Assinar(ControladorEmail controlador)
        {
            controlador.ProcessarEmail += ProcessarEmail;
        }

        public void ProcessarEmail()
        {
            Console.WriteLine("Email recebido pelo usuário A");
        }

        public void CancelarAssinatura(ControladorEmail controlador)
        {
            controlador.ProcessarEmail -= ProcessarEmail;
        }
    }

    public class UsuarioB
    {
        public void Assinar(ControladorEmail controlador)
        {
            controlador.ProcessarEmail += ProcessarEmail;
        }

        public void ProcessarEmail()
        {
            Console.WriteLine("Email recebido pelo usuário B");
        }


        public void CancelarAssinatura(ControladorEmail controlador)
        {
            controlador.ProcessarEmail -= ProcessarEmail;
        }
    }

    public class UsuarioC
    {
        public void Assinar(ControladorEmail controlador)
        {
            controlador.ProcessarEmail += ProcessarEmail;
        }

        public void ProcessarEmail()
        {
            Console.WriteLine("Email recebido pelo usuário C");
        }

        public void CancelarAssinatura(ControladorEmail controlador)
        {
            controlador.ProcessarEmail -= ProcessarEmail;
        }
    }
}
