using System.Collections.Generic;

namespace ClinicaVeterinaria
{
    public class Consulta
    {
        public static List<Consulta> consultas = new List<Consulta>();
        private readonly int _idServico;
        private readonly int _idProfissionalSaude;
        private readonly int _idAnimalEstimacao;
        private readonly int _idCliente;
        private readonly Período _periodo;

        public Consulta(int servico, int profissionalSaude, int animalEstimacao, Período periodo, int idCliente)
        {
            this._idServico = servico;
            this._idProfissionalSaude = profissionalSaude;
            this._idAnimalEstimacao = animalEstimacao;
            this._periodo = periodo;
            this._idCliente = idCliente;

            consultas.Add(this);
        }

        public int Servico
        {
            get => _idServico;
            set
            {
            }
        }

        public int ProfissionalSaude
        {
            get => _idProfissionalSaude;
            set
            {
            }
        }

        public int AnimalEstimacao
        {
            get => _idAnimalEstimacao;
            set
            {
            }
        }

        public Período Período
        {
            get => _periodo;
            set
            {
            }
        }

        public int Cliente
        {
            get => _idCliente;
            set
            {
            }
        }


    }
}