﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicaVeterinaria
{
    public interface IHumano
    {
        string Nome { get; set; }
        int Contacto { get; set; }
        string Endereço { get; set; }
    }
}