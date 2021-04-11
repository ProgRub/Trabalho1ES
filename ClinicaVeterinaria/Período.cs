using System;

namespace ClinicaVeterinaria
{
    public class Período
    {
        private readonly TimeSpan _inicio;
        private readonly TimeSpan _fim;
        private readonly DiaSemana _dia;

        public Período(DiaSemana dia, TimeSpan inicio, TimeSpan fim)
        {
            this._inicio = inicio;
            this._fim = fim;
            this._dia = dia;
        }

        public Período(DiaSemana dia, TimeSpan inicio, int duração)
        {
            this._inicio = inicio;
            this._fim = new TimeSpan(this._inicio.Hours+(duração / 60), this._inicio.Minutes + (duração % 60), 0);
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