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
            //teste do método IsNullOrEmpty
            string textoVazio = "";
            string textoNulo = null;
            string textoQualquer = "kjhfsdjhgsdfjksdf";

            Console.WriteLine(string.IsNullOrEmpty(textoVazio));
            Console.WriteLine();
            Console.WriteLine(string.IsNullOrEmpty(textoNulo));
            Console.WriteLine();
            Console.WriteLine(string.IsNullOrEmpty(textoQualquer));
            Console.WriteLine();

            ExtratorValorArgumentosURL extrator = new ExtratorValorArgumentosURL("oi");

            //teste do método IndexOf - char
            string url = "pagina?moedaOrigem=real&moedaDestino=dolar";

            int indiceInterrogacao = url.IndexOf('?');
            Console.WriteLine(indiceInterrogacao);
            Console.WriteLine(url);
            Console.WriteLine();

            string argumentos = url.Substring(indiceInterrogacao + 1);
            Console.WriteLine(argumentos);
            Console.WriteLine();

            //teste do método IndexOf - string
            string palavra = "moedaDestino=real";
            
            int indice = palavra.IndexOf("real");

            Console.WriteLine(indice);
            Console.WriteLine();
            Console.WriteLine(palavra.Substring(indice));

            //teste método Lenght
            string palavras = "moedaOrigem=real&moedaDestino=dolar";
            string nomeArgumento = "moedaDestino";
            
            int index = palavras.IndexOf(nomeArgumento);
            Console.WriteLine(index);
            Console.WriteLine();

            Console.WriteLine($"Tamanho da string nomeArgumento: {nomeArgumento.Length}");
            Console.WriteLine();

            Console.WriteLine(palavras);
            Console.WriteLine();
            Console.WriteLine(palavras.Substring(index));
            Console.WriteLine();
            Console.WriteLine(palavras.Substring(index + nomeArgumento.Length + 1));

            Console.ReadLine();
        }
    }
}