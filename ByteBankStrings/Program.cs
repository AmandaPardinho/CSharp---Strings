using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ByteBankStrings.SistemaAgencia;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            string textoVazio = "";
            string textoNulo = null;
            string textoQualquer = "kjhfsdjhgsdfjksdf";

            Console.WriteLine(string.IsNullOrEmpty(textoVazio));
            Console.WriteLine();
            Console.WriteLine(string.IsNullOrEmpty(textoNulo));
            Console.WriteLine();
            Console.WriteLine(string.IsNullOrEmpty(textoQualquer));
            Console.WriteLine();
            Console.ReadLine();

            ExtratorValorArgumentosURL extrator = new ExtratorValorArgumentosURL("");

            string url = "pagina?moedaOrigem=real&moedaDestino=dolar";

            int indiceInterrogacao = url.IndexOf('?');
            Console.WriteLine(indiceInterrogacao);
            Console.WriteLine(url);

            string argumentos = url.Substring(indiceInterrogacao + 1);
            Console.WriteLine(argumentos);

            Console.ReadLine();
        }
    }
}