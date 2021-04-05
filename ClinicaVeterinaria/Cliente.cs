using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ClinicaVeterinaria
{
    public class Cliente : IHumano
    {

        public static List<Cliente> clientes=new List<Cliente>();
        private readonly int _contacto, _ID;
        private readonly string _endereco;
        private readonly string _nome;
        private readonly List<int> _animaisEstimacao;
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


        public void CriarRelatório()
        {
            string path = Path.Combine(Path.GetFullPath(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), @"..\..\..\..\")), $"RelatorioCliente{this._ID}.txt");

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using StreamWriter sw = File.CreateText(path);

            sw.WriteLine($"RELATÓRIO - CLIENTE Nº {this._ID}");
            sw.WriteLine($"Nome: {this.Nome}");

            var consultasCliente = Consulta.consultas.Where(consulta => this._ID == consulta.Cliente).ToList();

            int nrConsultas = consultasCliente.Count();

            Frequência frequencia = Frequência.Nunca;

            switch (nrConsultas)
            {
                case 0:
                    break;
                case 1:
                case 2:
                    frequencia = Frequência.Raramente;
                    break;
                case 3:
                case 4:
                    frequencia = Frequência.Frequente;
                    break;
                default:
                    frequencia = Frequência.MuitoFrequente;
                    break;
            }


            sw.WriteLine($"Frequência: {frequencia}");
            sw.WriteLine($"Número de Consultas: {nrConsultas}");
            sw.WriteLine($"Animais de Estimação:");
            var animaisEstimacaoCliente = AnimalEstimacao.animaisEstimacao.Where(animal => this.AnimaisEstimacao.Contains(animal.ID)).ToList();
            foreach (AnimalEstimacao animal in animaisEstimacaoCliente)
            {
                sw.WriteLine($"- {animal.Nome}, {animal.Espécie}, {animal.Idade} anos, {animal.Género}");
            }


            sw.WriteLine($"Serviços Prestados:");
            foreach (Consulta consulta in consultasCliente)
            {
                foreach (Servico servico in Servico.servicos)
                {
                    if (servico.Id == consulta.Servico)
                    {
                        sw.WriteLine($"- {servico.Nome}");
                    }
                }
            }


        }


    }
}