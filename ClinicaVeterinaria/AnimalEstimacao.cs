using System;
using System.Collections.Generic;
using System.Text;


namespace ClinicaVeterinaria
{
    public class AnimalEstimacao
    {
        public static List<AnimalEstimacao> animaisEstimacao = new List<AnimalEstimacao>();
        private static int contadorID = 1;

        private string _nome, _especie;
        private int _idade, _ID;
        private Género _genero;

        public AnimalEstimacao(string nome, int idade, string especie, Género genero)
        {
            this._nome = nome;
            this._idade = idade;
            this._especie = especie;
            this._genero = genero;
            this._ID = contadorID++;
            animaisEstimacao.Add(this);
        }

        public string Nome
        {
            get => _nome;
            private set
            {
            }
        }

        public int Idade
        {
            get => _idade;
            private set
            {
            }
        }

        public string Espécie
        {
            get => _especie;
            private set
            {
            }
        }

        public int ID
        {
            get => _ID;
            private set
            {
            }
        }

        public Género Género
        {
            get => _genero;
            private set
            {
            }
        }
    }
}