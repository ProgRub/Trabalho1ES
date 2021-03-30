using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicaVeterinaria
{
    public class ProfissionalSaude : IHumano
    {

        public static List<ProfissionalSaude> profissionaisSaude=new List<ProfissionalSaude>();
        private static int ContadorID = 1;
        private int _contacto, _ID;
        private string _endereco;
        private string _nome;
        private Período _periodoDisponibilidade;


        public ProfissionalSaude(int contacto, string endereco, string nome, Período periodoDisponibilidade)
        {
            this._nome = nome;
            this._contacto = contacto;
            this._endereco = endereco;
            this._ID = ContadorID++;
            this._periodoDisponibilidade = periodoDisponibilidade;
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