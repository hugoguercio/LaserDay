using System;
using System.Collections.Generic;
using System.Text;

namespace LaserDay.Controllers
{
    class Paciente
    {
        public string nome { get; set; }
        public string telefone { get; set; }

        public Paciente(string nome, string telefone)
        {
            this.nome = nome;
            this.telefone = telefone;
        }
    }
}
