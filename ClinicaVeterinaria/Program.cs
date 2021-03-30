﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace ClinicaVeterinaria
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("CLINICA VETERINÁRIA");
                Menu();
            }
        }

        static void Menu()
        {
            Console.WriteLine("Por favor selecione uma opção\n1: Registar Animal\n2: Registar Cliente\n3: Criar Serviço");
            Console.Write("Opção: ");
            string input = Console.ReadLine();
            int opcao = 0;

            while (!int.TryParse(input, out opcao) && (opcao < 0 || opcao > 3))
            {
                Console.WriteLine("OPÇÃO INVÁLIDA!");
                Console.WriteLine("Por favor selecione uma opção\n1: Registar Animal\n2: Registar Cliente\n3: Criar Serviço");
                Console.Write("Opção: ");
                input = Console.ReadLine();
            }
            switch (opcao)
            {
                case 1:
                    RegistarAnimal();
                    break;
                case 2:
                    RegistarCliente();
                    break;
                case 3:
                    criarServiço();
                    break;
            }
        }

        static void RegistarAnimal()
        {
            string nome = "1";
            string especie = "1";
            int idade;
            Género genero = Género.Masculino;
            Console.WriteLine("REGISTAR ANIMAL DE ESTIMAÇÃO:");

            while (nome.All(char.IsDigit))
            {
                Console.Write("Insira o nome do animal (não pode conter dígitos): ");
                nome = Console.ReadLine();
            }

            while (especie.All(char.IsDigit))
            {
                Console.Write("Insira a espécie (não pode conter dígitos): ");
                especie = Console.ReadLine();
            }

            Console.Write("Insira a idade (não pode conter letras): ");
            string aux_Idade = Console.ReadLine();
            while (!int.TryParse(aux_Idade, out idade))
            {
                Console.Write("Insira a idade (não pode conter letras): ");
                aux_Idade = Console.ReadLine();
            }

            Console.Write("Insira o género (M-Masculino, F-Feminimo): ");
            string aux_Genero = Console.ReadLine();
            while (aux_Genero != "M" && aux_Genero != "F")
            {
                Console.Write("Insira o género (M-Masculino, F-Feminimo): ");
                aux_Genero = Console.ReadLine();
            }

            switch (aux_Genero)
            {
                case "M":
                    genero = Género.Masculino;
                    break;
                case "F":
                    genero = Género.Feminino;
                    break;
                default:
                    break;
            }

            AnimalEstimacao novoAnimal = new AnimalEstimacao(nome, idade, especie, genero);

        }

        static void RegistarCliente()
        {
            Console.WriteLine("REGISTAR CLIENTE:");
            string nome = "1";
            string endereco = "1";
            int contato;

            while (nome.All(char.IsDigit))
            {
                Console.Write("Insira o nome do cliente (não pode conter dígitos): ");
                nome = Console.ReadLine();
            }
            Console.Write("Insira o endereço e-mail do cliente: ");
            endereco = Console.ReadLine();

            while (!(new EmailAddressAttribute().IsValid(endereco)))
            {
                Console.WriteLine("ENDEREÇO INVÁLIDO");
                Console.Write("Insira o endereço e-mail do cliente: ");
                endereco = Console.ReadLine();
            }

            Console.Write("Insira o número telefónico do cliente (não pode conter letras e deve ter 9 dígitos): ");
            string stringContato = Console.ReadLine();
            while (!int.TryParse(stringContato, out contato) || stringContato.Length != 9)
            {
                Console.Write("Insira o número telefónico do cliente (não pode conter letras e deve ter 9 dígitos): ");
                stringContato = Console.ReadLine();
            }

            Console.WriteLine("Insira os números dos animais de estimação que quer associar a este cliente separados por vírgulas.");
            foreach (AnimalEstimacao animal in AnimalEstimacao.animaisEstimacao)
            {
                Console.WriteLine($"{animal.ID}. {animal.Nome}, {animal.Espécie}, {animal.Idade}, {animal.Género}");
            }
            Console.Write("Resposta:");
            string animais = Console.ReadLine();
            string[] StringsIDsAnimais = animais.Split(",");
            while (!StringsIDsAnimais.All(id => int.TryParse(id, out _)))
            {
                Console.Write($"Pelo menos um dos valores não é um número, tente outra vez{Environment.NewLine}Resposta:");
                animais = Console.ReadLine();
                StringsIDsAnimais = animais.Split(",");
            }
            List<int> IDsAnimaisSelecionados = new List<int>();
            List<int> IDsAnimaisRegistados = AnimalEstimacao.animaisEstimacao.Select(animal => animal.ID).ToList();
            foreach (string  ID in StringsIDsAnimais)
            {
                if(IDsAnimaisRegistados.Contains(int.Parse(ID)))
                    IDsAnimaisSelecionados.Add(int.Parse(ID));
            }
            new Cliente(contato, endereco, nome, IDsAnimaisSelecionados);
            //foreach (int IDAnimal in Cliente.clientes.Last().AnimaisEstimacao)
            //{
            //    Console.WriteLine(AnimalEstimacao.animaisEstimacao.Where(x => x.ID == IDAnimal).ToList()[0].Nome);
            //}
        }

        static void criarServiço()
        {
            Console.WriteLine("CRIAR SERVIÇO:");
            string nome = "1";
            string medicamentos = "1";

            while (nome.All(char.IsDigit))
            {
                Console.Write("Insira o nome do cliente (não pode conter dígitos): ");
                nome = Console.ReadLine();
            }

            Console.Write("Insira o nome dos medicamentos (caso existam):");
            medicamentos = Console.ReadLine();

            Console.Write("Insira o preço:");
            string stringPreço = Console.ReadLine();
            double preço;
            while (!double.TryParse(stringPreço, out preço))
            {
                Console.Write("Insira o preço:");
                stringPreço = Console.ReadLine();
            }

            Console.Write("Insira a duração (em minutos):");
            string stringDuração = Console.ReadLine();
            int duração;
            while (!int.TryParse(stringDuração, out duração))
            {
                Console.Write("Insira a duração (em minutos):");
                stringPreço = Console.ReadLine();
            }

            new Servico(new TimeSpan(0, duração, 0), medicamentos, preço, nome);

            
        }
    }
}
