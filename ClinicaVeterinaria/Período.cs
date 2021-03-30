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

        public Período(DiaSemana dia, TimeSpan inicio, int duração)
        {
            this._inicio = inicio;
            this._fim = _inicio + (new TimeSpan((int)(duração / 60), duração % 60, 0));
            this._dia = dia;
        }



        public TimeSpan Início
        {
            get => _inicio;
            set
            {
            }
        }

        public TimeSpan Fim
        {
            get => _fim;
            set
            {
            }
        }

        public DiaSemana Dia
        {
            get => _dia;
            set
            {
            }
        }

    }
}