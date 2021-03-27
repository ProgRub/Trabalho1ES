using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicaVeterinaria
{
    public class Cliente : IHumano
    {
        public Cliente(int contacto, string endereco, string nome)
        {
            this.Nome = nome;
            this.Contacto = contacto;
            this.Endereço = endereco;
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