using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dados;
using NHibernate;
using System.Net;
using System.IO;
using NHibernate.Criterion;
using System.Configuration;

namespace GeradorCNARH
{
    class Program
    {
        static void Main(string[] args)
        {
            Escritor.CriarArquivoCNARH();
        }
    }
}
