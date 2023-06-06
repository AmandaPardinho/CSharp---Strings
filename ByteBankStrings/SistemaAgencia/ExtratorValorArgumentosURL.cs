using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankStrings.SistemaAgencia
{
    public class ExtratorValorArgumentosURL
    {
        private readonly string _argumentos;

        public string URL { get; }

        public ExtratorValorArgumentosURL(string url)
        {
            if(string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("O argumento url não pode ser uma string vazia", nameof(url));
            }

            URL = url;

            int indiceInterrogacao = URL.IndexOf('?');
            _argumentos = URL.Substring(indiceInterrogacao + 1);
        }

        public string GetValor(string nomeParametro)
        {
            string termo = nomeParametro + "="; //moedaDestino=
            int indiceTermo = _argumentos.IndexOf(termo);

            string resultado = _argumentos.Substring(indiceTermo + termo.Length); //dolar

            int indiceEComercial = resultado.IndexOf('&');

            if(indiceEComercial == -1)
            {
                return resultado;
            }

            return resultado.Remove(indiceEComercial);
        }
    }
}
