using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using ByteBankStrings.Modelos.Conta;
using ByteBankStrings.Modelos.Funcionarios;
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

            //teste métodos StartsWith, EndsWith e Contains
            string urlTeste = "http://www.bytebank.com/cambio";
            int indiceByteBank = urlTeste.IndexOf("http://www.bytebank.com/cambio");

            Console.WriteLine(indiceByteBank == 0);
            Console.WriteLine();

            /* StartsWith e EndsWith => 
             * métodos usados sempre que o índice não for importante
             * retornam um booleano
             */
            Console.WriteLine(urlTeste.StartsWith("http://www.bytebank.com"));
            Console.WriteLine();

            Console.WriteLine(urlTeste.EndsWith("cambio"));
            Console.WriteLine();

            /* Contains =>
             * retorna um booleano
             * indica se uma determinada subcadeia de caracteres está contida na cadeia de caracteres especificada
             */
            Console.WriteLine(urlTeste.Contains("bytebank"));
            Console.WriteLine();
            Console.WriteLine(urlTeste.Contains("ByteBank"));
            Console.WriteLine();

            //teste Regex
            /* Expressão regular =>
             * expressões que se encontram dentro de uma determinada regra
             * representada pela classe Regex
             * a definição do padrão não precisa conter todos os componentes do intervalo; basta o primeiro elemento e o último, separados por um hífen
             * ** A definição dos elementos se baseia na Tabela ASCII
             * ** se um padrão se repetir mais de uma vez, é possível determinar o número de vezes (quantificador) entre chaves após o padrão
             */
            /* texto 1:
             * ** Olá, meu nome é Guilherme e você pode entrar em contato comigo através do número 8457-4456!
             * texto 2:
             * ** Meu nome é Guilherme, me ligue em 4784-4546
             */
            //string padrao = [0123456789][0123456789][0123456789][0123456789][-][0123456789][0123456789][0123456789][0123456789]; //expressão regular
            //string padrao = [0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9];
            string padrao = "[0-9]{4}[-][0-9]{4}"; 
            string textoTeste = "Meu nome é Guilherme, me ligue em 4784-4546";
            
            Console.WriteLine("O texto teste possui o padrão? " + Regex.IsMatch(textoTeste, padrao));
            Console.WriteLine();

            Match resultado = Regex.Match(textoTeste, padrao);
            Console.WriteLine($"Valor encontrado: {resultado.Value}");
            Console.WriteLine();

            //minha resolução
            string textoTeste2 = "Meu nome é Guilherme, me ligue em 94784-4546";
            string padraoCelular = "[9][0-9]{4}[-][0-9]{4}";

            Console.WriteLine("O novo texto possui esse padrão? " + Regex.IsMatch(textoTeste2, padraoCelular));
            Console.WriteLine();

            Match resultadoCelular = Regex.Match(textoTeste2, padraoCelular);
            Console.WriteLine($"Valor encontrado: {resultadoCelular.Value}");
            Console.WriteLine();

            //resolução do professor
            string textoTeste3 = "Meu nome é Guilherme, me ligue em 94784-4546";
            //string padraoCelular2 = "[0-9]{4,5}[-][0-9]{4}";
            //string textoTeste3 = "Meu nome é Guilherme, me ligue em 947844546";
            //string padraoCelular2 = "[0-9]{4,5}[-]{0,1}[0-9]{4}";
            string padraoCelular2 = "[0-9]{4,5}-?[0-9]{4}";
                //não pode ter espaço depois da vírgula
                //a vírgula tem valor de "OU"
                //a substituição pela interrogação funciona apenas para {0,1}

            Console.WriteLine("O novo texto possui esse padrão? " + Regex.IsMatch(textoTeste3, padraoCelular2));
            Console.WriteLine();

            Match resultadoCelular2 = Regex.Match(textoTeste3, padraoCelular2);
            Console.WriteLine($"Valor encontrado: {resultadoCelular2.Value}");
            Console.WriteLine();

            /*classe object
             * toda classe faz referência à classe object
             */
            //todo método virtual pode ser sobrescrito
             
            Console.WriteLine("Olá, mundo!");
            Console.WriteLine(123);
            Console.WriteLine(10.5);
            Console.WriteLine(true);
            Console.WriteLine();

            object conta = new ContaCorrente(456, 687876);
            object desenvolvedor = new Desenvolvedor("4564564");
            Console.WriteLine();

            string contaToString = conta.ToString();
            Console.WriteLine();

            Console.WriteLine($"Resultado: {contaToString}");
            //Console.WriteLine(conta);
            Console.WriteLine();

            //método Equals
            Cliente carlos_1 = new Cliente();
            carlos_1.Nome = "Carlos";
            carlos_1.CPF = "123.654.789-99";
            carlos_1.Profissao = "Designer";

            Cliente carlos_2 = new Cliente();
            carlos_2.Nome = "Carlos";
            carlos_2.CPF = "123.654.789-99";
            carlos_2.Profissao = "Designer";

            if(carlos_1 == carlos_2)
            {
                Console.WriteLine("São iguais!");
            }
            else
            {
                Console.WriteLine("São diferentes!"); //Resposta dessa condição
            }
            Console.WriteLine();

            if (carlos_1.Equals(carlos_2))
            {
                Console.WriteLine("São iguais!"); //Resposta dessa condição após sobrescrever o método Equals
            }
            else
            {
                Console.WriteLine("São diferentes!"); 
            }
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}