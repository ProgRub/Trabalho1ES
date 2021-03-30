using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicaVeterinaria
{
    public class Servico : IServico
    {

        public static List<Servico> servicos=new List<Servico>();
        private TimeSpan _duracao;
        private string _medicamentos;
        private string _nome;
        private double _preco;
        private int _ID;
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