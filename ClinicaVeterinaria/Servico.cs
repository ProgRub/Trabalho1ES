using System;
using System.Collections.Generic;

namespace ClinicaVeterinaria
{
    public class Servico : IServico
    {

        public static List<Servico> servicos=new List<Servico>();
        private readonly TimeSpan _duracao;
        private readonly string _medicamentos;
        private readonly string _nome;
        private readonly double _preco;
        private readonly int _ID;
        private static int ID = 1;

        public Servico(TimeSpan duracao, string medicamentos, double preco, string nome)
        {
            this._nome = nome;
            this._preco = preco;
            this._medicamentos = medicamentos;
            this._duracao = duracao;
            this._ID = ID++;

            servicos.Add(this);
        }

        public TimeSpan Duração
        {
            get => _duracao;
            set
            {
            }
        }

        public string Medicamentos
        {
            get => _medicamentos;
            set
            {
            }
        }

        public double Preço
        {
            get => _preco;
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
    }
}