using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicaVeterinaria
{
    public class Servico : IServico
    {

        public static List<Servico> servicos;
        public Servico(TimeSpan duracao, string medicamentos, double preco, string nome)
        {
            this.Nome = nome;
            this.Preço = preco;
            this.Medicamentos = medicamentos;
            this.Duração = duracao;

            servicos.Add(this);
        }

        public TimeSpan Duração
        {
            get => default;
            set
            {
            }
        }

        public string Medicamentos
        {
            get => default;
            set
            {
            }
        }

        public double Preço
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