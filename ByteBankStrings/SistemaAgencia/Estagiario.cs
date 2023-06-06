using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBankStrings.Modelos.Funcionarios;

namespace ByteBankStrings.SistemaAgencia
{
    public class Estagiario: Funcionario
    {
        public Estagiario(double salario, string cpf): base(salario, cpf)
        {
            
        }

        public override void AumentarSalario() { }

        internal protected override double GetBonificacao()
        {
            throw new NotImplementedException();
        }
    }
}
