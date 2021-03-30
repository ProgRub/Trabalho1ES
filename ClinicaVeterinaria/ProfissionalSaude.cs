using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicaVeterinaria
{
    public class ProfissionalSaude : IHumano
    {

        public static List<ProfissionalSaude> profissionaisSaude=new List<ProfissionalSaude>();
        private static int ContadorID = 1;
        private int _contacto, _ID;
        private string _endereco;
        private string _nome;
        private List<Período> _periodosDisponibilidade;


        public ProfissionalSaude(int contacto, string endereco, string nome)
        {
            this._nome = nome;
            this._contacto = contacto;
            this._endereco = endereco;
            this._ID = ContadorID++;
            this._periodosDisponibilidade = new List<Período>();
            foreach (DiaSemana dia in (DiaSemana[])Enum.GetValues(typeof(DiaSemana)))
            {
                this._periodosDisponibilidade.Add(new Período(dia, new TimeSpan(10, 0, 0),new TimeSpan(13,0,0)));
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

        public bool EstaDisponivel(Período periodoConsulta)
        {
            foreach (Período período in _periodosDisponibilidade)
            {
                if (período.Dia == periodoConsulta.Dia && período.Início<periodoConsulta.Início && período.Fim>periodoConsulta.Fim)
                {
                    ReajustarDisponibilidade(_periodosDisponibilidade.IndexOf(período),periodoConsulta);
                    return true;
                }
            }
            return false;
        }

        private void ReajustarDisponibilidade(int indexPeriodoARemover,Período periodoIndisponibilidade)
        {
            Período periodoARemover = _periodosDisponibilidade[indexPeriodoARemover];
            Período novoPeriodo1 = new Período(periodoARemover.Dia, periodoARemover.Início, periodoIndisponibilidade.Início);
            Período novoPeriodo2 = new Período(periodoARemover.Dia, periodoIndisponibilidade.Fim, periodoARemover.Fim);
            _periodosDisponibilidade.RemoveAt(indexPeriodoARemover);
            _periodosDisponibilidade.Insert(indexPeriodoARemover, novoPeriodo1);
            _periodosDisponibilidade.Insert(indexPeriodoARemover+1, novoPeriodo2);

        }
    }
}