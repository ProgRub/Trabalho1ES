using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicaVeterinaria
{
    public class Consulta
    {
        private Servico _servico;
        private ProfissionalSaude _profissionalSaude;
        private AnimalEstimacao _animalEstimacao;
        private Período _periodo;

        public Consulta(Servico servico, ProfissionalSaude profissionalSaude, AnimalEstimacao animalEstimacao, Período periodo)
        {
            this._servico = servico;
            this._profissionalSaude = profissionalSaude;
            this._animalEstimacao = animalEstimacao;
            this._periodo = periodo;
        }

        public Servico Servico
        {
            get => _servico;
            set
            {
            }
        }

        public ProfissionalSaude ProfissionalSaude
        {
            get => _profissionalSaude;
            set
            {
            }
        }

        public AnimalEstimacao AnimalEstimacao
        {
            get => _animalEstimacao;
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
    }
}