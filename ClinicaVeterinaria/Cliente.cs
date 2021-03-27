﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicaVeterinaria
{
    public class Cliente : IHumano
    {

        public static List<Cliente> clientes=new List<Cliente>();
        private int _contacto;
        private string _endereco;
        private string _nome;

        public Cliente(int contacto, string endereco, string nome)
        {
            this._nome = nome;
            this._contacto = contacto;
            this._endereco = endereco;
            clientes.Add(this);
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