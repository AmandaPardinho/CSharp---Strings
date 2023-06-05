using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace bytebank_URL
{
    public class Program
    {
        static void Main(string[] args)
        {
            /* índices de uma string:
             * p a g i n a ? a r g u  m  e  n  t  o  s
             * 0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16
             * ** cada caractere representa um valor do índice
             * ** na substring acima, os caracteres foram separados para que a visualização ficasse mais fácil
             * o objeto string é um objeto imutável
             * ** para fazer operações é necessário criar um novo objeto
             * ** quando fazemos uma concatenação, uma variável temporária é criada e, depois, o valor dessa variável temporária é atribuído à variável original
             */
            string url = "pagina?argumentos";
            Console.WriteLine(url);
            Console.WriteLine();

            string url2 = "pagina?moedaOrigem=real&moedaDestino=dolar";

            int indiceInterrogacao = url.IndexOf('?');
            Console.WriteLine(indiceInterrogacao);
            Console.WriteLine();

            string argumentos = url.Substring(indiceInterrogacao + 1);
            Console.WriteLine(argumentos);
            Console.WriteLine();


            Console.ReadKey();
        }
    }
}