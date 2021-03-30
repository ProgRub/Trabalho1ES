using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicaVeterinaria
{
    public class Período
    {
        private TimeSpan _inicio;
        private TimeSpan _fim;
        private DiaSemana _dia;

        public Período(DiaSemana dia, TimeSpan inicio, TimeSpan fim)
        {
            this._inicio = inicio;
            this._fim = fim;
            this._dia = dia;

        }

        public TimeSpan Início
        {
            get => default;
            set
            {
            }
        }

        public TimeSpan Fim
        {
            get => default;
            set
            {
            }
        }

        public DiaSemana Dia
        {
            get => default;
            set
            {
            }
        }
    }
}