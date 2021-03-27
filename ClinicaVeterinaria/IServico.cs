using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicaVeterinaria
{
    public interface IServico
    {
        double Preço { get; set; }
        TimeSpan Duração { get; set; }
        string Medicamentos { get; set; }
        string Nome { get; set; }
    }
}