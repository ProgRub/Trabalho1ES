using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicaVeterinaria
{
    public class ProfissionalSaude : IHumano
    {

        public static List<ProfissionalSaude> profissionaisSaude;
        public ProfissionalSaude(int contacto, string endereco, string nome)
        {
            this.Nome = nome;
            this.Contacto = contacto;
            this.Endereço = endereco;
            profissionaisSaude.Add(this);
        }

        public int Contacto
        {
            get => default;
            set
            {
            }
        }

        public string Endereço
        {
            get => default;
            set
            {
            }
        }

        public string Nome
        {
            get => default;
            set
            {
            }
        }
    }
}