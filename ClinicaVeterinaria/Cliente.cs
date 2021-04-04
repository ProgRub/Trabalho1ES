using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

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
        private int _nrConsultas;
        private Frequência _frequencia;

        public Cliente(int contacto, string endereco, string nome, List<int> animaisEstimacao)
        {

            this._ID = ID++;
            this._nome = nome;
            this._contacto = contacto;
            this._endereco = endereco;
            this._animaisEstimacao = animaisEstimacao;
            this._nrConsultas = 0;
            this._frequencia = Frequência.Nunca;
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

        public int NrConsultas
        {
            get => _nrConsultas;
            set
            {
            }
        }

        public Frequência Frequencia
        {
            get => _frequencia;
            set
            {
            }
        }

        public void criarRelatório()
        {

            string path = $@"C:\Users\diego\Documents\GitHub\Trabalho1ES\RelatorioCliente{_ID}.txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {

                    sw.WriteLine($"RELATÓRIO - CLIENTE Nº {_ID}");
                    sw.WriteLine($"Nome: {Cliente.clientes[_ID - 1].Nome}");
                    sw.WriteLine($"Frequência: {Cliente.clientes[_ID - 1].Frequencia}");
                    sw.WriteLine($"Número de Consultas: {Cliente.clientes[_ID - 1].NrConsultas}");
                    sw.WriteLine($"Animais de Estimação:");
                    var animaisEstimacaoCliente = AnimalEstimacao.animaisEstimacao.Where(animal => Cliente.clientes[_ID - 1].AnimaisEstimacao.Contains(animal.ID)).ToList();
                    foreach (AnimalEstimacao animal in animaisEstimacaoCliente)
                    {
                        sw.WriteLine($"- {animal.Nome}, {animal.Espécie}, {animal.Idade} anos, {animal.Género}");
                    }

                    sw.WriteLine($"Serviços Prestados:");
                    var consultasCliente = Consulta.consultas.Where(consulta => Cliente.clientes[_ID - 1]._ID == consulta.Cliente).ToList();

                    foreach (Consulta consulta in consultasCliente)
                    {
                        foreach(Servico servico in Servico.servicos)
                        {
                            if(servico.Id == consulta.Servico)
                            {
                                sw.WriteLine($"- {servico.Nome}");
                            }
                        }
                    }

                }
            }


        }


    }
}