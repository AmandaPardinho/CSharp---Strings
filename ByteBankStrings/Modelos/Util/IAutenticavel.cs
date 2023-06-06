using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankStrings.Modelos.Util
{
    public interface IAutenticavel
    {
        bool Autenticar(string senha);
    }
}
