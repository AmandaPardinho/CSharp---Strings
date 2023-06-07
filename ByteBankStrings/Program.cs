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
            string nomeArgumento = "moedaDestino=";
            
            int index = palavras.IndexOf(nomeArgumento);
            Console.WriteLine(index);
            Console.WriteLine();

            Console.WriteLine($"Tamanho da string nomeArgumento: {nomeArgumento.Length}");
            Console.WriteLine();

            Console.WriteLine(palavras);
            Console.WriteLine();
            Console.WriteLine(palavras.Substring(index));
            Console.WriteLine();
            Console.WriteLine(palavras.Substring(index + nomeArgumento.Length));
            Console.WriteLine();

            //teste método GetValor
            string urlParametros = "http://www.bytebank.com/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";

            ExtratorValorArgumentosURL extratorValores = new ExtratorValorArgumentosURL(urlParametros);
            
            string valorMoedaDestino = extratorValores.GetValor("moedaDestino");
            Console.WriteLine($"Valor de moedaDestino: {valorMoedaDestino}");
            Console.WriteLine();

            string valorMoedaOrigem = extratorValores.GetValor("moedaOrigem");
            Console.WriteLine($"Valor de moedaOrigem: {valorMoedaOrigem}");
            Console.WriteLine();

            string valorDinheiro = extratorValores.GetValor("valor");
            Console.WriteLine($"Valor de dinheiro a ser trocado: R$ {(String.Format("{0:0.00}", valorDinheiro))}");
            Console.WriteLine();

            //teste método Remove
            string testeRemocao = "primeiraParte&parteParaRemover";
            int indiceEComercial = testeRemocao.IndexOf('&');

            Console.WriteLine(testeRemocao.Remove(indiceEComercial));
            Console.WriteLine();

            //teste métodos Replace, ToUpper, ToLower
            string mensagemOrigem = "PALAVRA";
            string termoBusca = "ra";

            termoBusca = termoBusca.Replace('r', 'R');
            Console.WriteLine(termoBusca);
            Console.WriteLine();

            termoBusca = termoBusca.Replace('a', 'A');
            Console.WriteLine(termoBusca);
            Console.WriteLine();

            Console.WriteLine(mensagemOrigem.IndexOf(termoBusca));
            Console.WriteLine();

            Console.WriteLine(termoBusca.ToUpper());
            Console.WriteLine();

            Console.WriteLine(mensagemOrigem.ToLower());
            Console.WriteLine();

            //teste método GetValor com tudo em maiúsculo
            string urlParametros1 = "http://www.bytebank.com/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";

            ExtratorValorArgumentosURL extratorValores1 = new ExtratorValorArgumentosURL(urlParametros1);

            string valorMoedaDestino1 = extratorValores1.GetValor("moedaDestino");
            Console.WriteLine($"Valor de moedaDestino: {valorMoedaDestino1}");
            Console.WriteLine();

            string valorMoedaOrigem1 = extratorValores1.GetValor("moedaOrigem");
            Console.WriteLine($"Valor de moedaOrigem: {valorMoedaOrigem1}");
            Console.WriteLine();

            string valorDinheiro1 = extratorValores1.GetValor("VALOR");
            Console.WriteLine($"Valor de dinheiro a ser trocado: R$ {(String.Format("{0:0.00}", valorDinheiro1))}");
            Console.WriteLine();



            Console.ReadLine();
        }
    }
}