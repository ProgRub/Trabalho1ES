using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicaVeterinaria
{
    public class Consulta
    {
        public static List<Consulta> consultas = new List<Consulta>();
        private int _idServico;
        private int _idProfissionalSaude;
        private int _idAnimalEstimacao;
        private int _idCliente;
        private Período _periodo;

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