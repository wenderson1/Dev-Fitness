using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFitness.ConsoleApp
{
    public class Refeicao
    {
        protected int valor = 10;
        public string Descricao { get; set; }
        public int Calorias { get; set; }

        public virtual void ImprimirMensagem()
        {
            Console.WriteLine($"{Descricao}, com {Calorias} Calorias");
        }

        public Refeicao(string descricao, int calorias)
        {
            Descricao = descricao;
            Calorias = calorias;
        }


    }
}
