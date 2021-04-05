using System;
using System.Collections.Generic;

namespace ClinicaVeterinaria
{
    public class ProfissionalSaude : IHumano
    {

        public static List<ProfissionalSaude> profissionaisSaude = new List<ProfissionalSaude>();
        private static int ContadorID = 1;
        private readonly int _contacto, _ID;
        private readonly string _endereco;
        private readonly string _nome;
        private readonly List<Período> _periodosDisponibilidade;


        public ProfissionalSaude(int contacto, string endereco, string nome)
        {
            this._nome = nome;
            this._contacto = contacto;
            this._endereco = endereco;
            this._ID = ContadorID++;
            this._periodosDisponibilidade = new List<Período>();
            foreach (DiaSemana dia in (DiaSemana[])Enum.GetValues(typeof(DiaSemana)))
            {
                this._periodosDisponibilidade.Add(new Período(dia, new TimeSpan(10, 0, 0), new TimeSpan(13, 0, 0)));
                this._periodosDisponibilidade.Add(new Período(dia, new TimeSpan(14, 0, 0), new TimeSpan(17, 0, 0)));
            }
            profissionaisSaude.Add(this);
        }

        public int Contacto
        {
            get => _contacto;
            set
            {
            }
        }

        public string Endereço
        {
            get => _endereco;
            set
            {
            }
        }

        public string Nome
        {
            get => _nome;
            set
            {
            }
        }

        public int Id
        {
            get => _ID;
            set
            {
            }
        }

        public List<Período> PeriodosDisponibilidade
        {
            get => _periodosDisponibilidade;
            set
            {
            }
        }

        public static bool VerificarDisponibilidadeProfissionais(Período periodoConsulta)
        {
            foreach (ProfissionalSaude profissionalSaude in profissionaisSaude)
            {
                if (profissionalSaude.EstaDisponivel(periodoConsulta))
                {
                    return true;
                }
            }
            return false;
        }

        public bool EstaDisponivel(Período periodoConsulta)
        {
            foreach (Período período in _periodosDisponibilidade)
            {
                if (período.Dia == periodoConsulta.Dia && período.Início <= periodoConsulta.Início && período.Fim >= periodoConsulta.Fim)
                {
                    return true;
                }
            }
            return false;
        }

        public void ReajustarDisponibilidade(Período periodoConsulta)
        {
            Período periodoARemover = null;
            int indexPeriodoARemover = 0;
            foreach (Período período in _periodosDisponibilidade)
            {
                if (período.Dia == periodoConsulta.Dia && período.Início <= periodoConsulta.Início && período.Fim >= periodoConsulta.Fim)
                {
                    periodoARemover = período;
                    break;
                }
                indexPeriodoARemover++;
            }
            Período novoPeriodo1 = null, novoPeriodo2;
            _periodosDisponibilidade.RemoveAt(indexPeriodoARemover);
            if (periodoARemover.Início != periodoConsulta.Início)
            { //se o periodo de consulta não começa no início do período de disponibilidade então é preciso fazer um novo período que acaba no início do período da consulta
                novoPeriodo1 = new Período(periodoARemover.Dia, periodoARemover.Início, periodoConsulta.Início);
                _periodosDisponibilidade.Insert(indexPeriodoARemover, novoPeriodo1);
            }
            if (periodoARemover.Fim != periodoConsulta.Fim)
            { //se o periodo de consulta não acaba ao mesmo tempo que o periodo de disponibilidade do profissional então é preciso acrescentar um periodo que acabe antes do início do periodo da consulta
                novoPeriodo2 = new Período(periodoARemover.Dia, periodoConsulta.Fim, periodoARemover.Fim);
                _periodosDisponibilidade.Insert(novoPeriodo1 == null ? indexPeriodoARemover + 1 : indexPeriodoARemover, novoPeriodo2);
            }
        }
    }
}