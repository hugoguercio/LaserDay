using LaserDay.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaserDay.Models
{
    class Procedimento
    {
        public Paciente paciente { get; set; }

        public TimeSpan horario { get; set; }

        public Procedimento(Paciente paciente, TimeSpan horario)
        {
            this.paciente = paciente;
            this.horario = horario;
        }
    }
}
