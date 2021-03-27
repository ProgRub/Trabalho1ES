using System;
using System.Collections.Generic;
using System.Text;


namespace ClinicaVeterinaria
{
    public class AnimalEstimacao
    {
        public static List<AnimalEstimacao> animaisEstimacao;
        private static int animalEstimacaoID = 1;

        public AnimalEstimacao(string nome, int idade, string especie, Género genero)
        {
            this.Nome = nome;
            this.Idade = idade;
            this.Espécie = especie;
            this.Género = genero;
            this.ID = animalEstimacaoID++;
            animaisEstimacao.Add(this);
        }

        private string Nome
        {
            get => default;
            set
            {
            }
        }

        private int Idade
        {
            get => default;
            set
            {
            }
        }

        private string Espécie
        {
            get => default;
            set
            {
            }
        }

        private int ID
        {
            get => default;
            set
            {
            }
        }

        public Género Género
        {
            get => default;
            set
            {
            }
        }
    }
}