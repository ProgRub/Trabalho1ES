using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicaVeterinaria
{
    public class ProfissionalSaude : IHumano
    {

        public static List<ProfissionalSaude> profissionaisSaude;
        private int _contacto;
        private string _endereco;
        private string _nome;

        public ProfissionalSaude(int contacto, string endereco, string nome)
        {
            this._nome = nome;
            this._contacto = contacto;
            this._endereco = endereco;
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
    }
}