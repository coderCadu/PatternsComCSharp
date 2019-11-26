using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var instance = SingletonClass.getInstance;
        }
    }

    public sealed class SingletonClass
    {
        static SingletonClass _instance;
        public static SingletonClass getInstance
        {
            get { return _instance ?? (_instance = new SingletonClass()); }
        }

        private SingletonClass()
        {

        }

        public string Message { get; set; }
    }
}
