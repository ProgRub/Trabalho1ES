using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicaVeterinaria
{
    public class Cliente : IHumano
    {

        public static List<Cliente> clientes=new List<Cliente>();
        private int _contacto, _ID;
        private string _endereco;
        private string _nome;
        private List<int> _animaisEstimacao;
        private static int ID = 1;

        public Cliente(int contacto, string endereco, string nome, List<int> animaisEstimacao)
        {

            this._ID = ID++;
            this._nome = nome;
            this._contacto = contacto;
            this._endereco = endereco;
            this._animaisEstimacao = animaisEstimacao;
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

        public int Id
        {
            get => _ID;
            set
            {
            }
        }

        public List<int> AnimaisEstimacao
        {
            get => _animaisEstimacao;
            set
            {
            }
        }
    }
}