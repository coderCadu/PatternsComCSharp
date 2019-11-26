using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverInterfacesDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Email email = new Email();

            EmailController emailController = new EmailController(email);

            Console.WriteLine("Os usuários A, B e C cadastraram-se para receber as promoções \n");

            UserA userA = new UserA(emailController);
            UserB userB = new UserB(emailController);
            UserC userC = new UserC(emailController);

            Console.WriteLine("Enviando os emails para os usuários cadastrados. \n");

            emailController.SendEmail();

            Console.WriteLine("\n O usuário A resolveu cancelar a assinatura e não irar receber mais emails. \n");

            userA.Dispose();

            Console.WriteLine("Enviando emails para os usuários cadastrados. \n");

            emailController.SendEmail();

            Console.ReadKey();
        }
    }
}
