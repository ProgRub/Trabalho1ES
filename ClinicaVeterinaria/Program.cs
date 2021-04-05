using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace ClinicaVeterinaria
{
    class Program
    {
        static void Main(string[] args)
        {
            string aux = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string dir = Path.GetFullPath(Path.Combine(aux, @"..\..\..\..\"));
            string filePath = Path.Combine(dir, "RelatorioCliente1.txt");
            Console.WriteLine(filePath);

            new ProfissionalSaude(999999999, "aaa@gmail.com", "Rúben");
            new ProfissionalSaude(888888888, "bbb@gmail.com", "Diego");
            new ProfissionalSaude(777777777, "ccc@gmail.com", "Maria");
            Período periodoConsulta = new Período(DiaSemana.Segunda, new TimeSpan(11, 0, 0), new TimeSpan(12, 0, 0));

            ProfissionalSaude.profissionaisSaude[0].ReajustarDisponibilidade(periodoConsulta);

            while (true)
            {

                Console.Clear();
                Menu();
            }
        }

        static void Menu()
        {
            Console.WriteLine("CLINICA VETERINÁRIA");
            Console.WriteLine("Por favor selecione uma opção\n1: Registar Animal\n2: Registar Cliente\n3: Criar Serviço\n4: Marcar Consulta\n5: Criar Relatório");
            Console.Write("Opção: ");
            string input = Console.ReadLine();
            int opcao;

            while (!int.TryParse(input, out opcao) && (opcao < 0 || opcao > 6))
            {
                Console.WriteLine("OPÇÃO INVÁLIDA!");
                Console.WriteLine("Por favor selecione uma opção\n1: Registar Animal\n2: Registar Cliente\n3: Criar Serviço\n4: Marcar Consulta\n5: Criar Relatório");
                Console.Write("Opção: ");
                input = Console.ReadLine();
            }
            Console.Clear();
            switch (opcao)
            {
                case 1:
                    RegistarAnimal();
                    break;
                case 2:
                    RegistarCliente();
                    break;
                case 3:
                    CriarServiço();
                    break;
                case 4:
                    MarcarConsulta();
                    break;
                case 5:
                    CriarRelatórioCliente();
                    break;
            }
        }

        static void RegistarAnimal()
        {
            string nomeAnimal = "1";
            string especieAnimal = "1";
            int idadeAnimal;
            Género generoAnimal = Género.Masculino;
            Console.WriteLine("REGISTAR ANIMAL DE ESTIMAÇÃO:");

            while (nomeAnimal.All(char.IsDigit))
            {
                Console.Write("\nInsira o nome do animal (não pode conter dígitos): ");
                nomeAnimal = Console.ReadLine();
            }

            while (especieAnimal.All(char.IsDigit))
            {
                Console.Write("\nInsira a espécie (não pode conter dígitos): ");
                especieAnimal = Console.ReadLine();
            }

            Console.Write("\nInsira a idade (não pode conter letras): ");
            string auxIdadeAnimal = Console.ReadLine();
            while (!int.TryParse(auxIdadeAnimal, out idadeAnimal))
            {
                Console.Write("\nInsira a idade (não pode conter letras): ");
                auxIdadeAnimal = Console.ReadLine();
            }

            Console.Write("\nInsira o género (M-Masculino, F-Feminimo): ");
            string auxGeneroAnimal = Console.ReadLine();
            while (auxGeneroAnimal != "M" && auxGeneroAnimal != "F")
            {
                Console.Write("\nInsira o género (M-Masculino, F-Feminimo): ");
                auxGeneroAnimal = Console.ReadLine();
            }

            switch (auxGeneroAnimal)
            {
                case "M":
                    generoAnimal = Género.Masculino;
                    break;
                case "F":
                    generoAnimal = Género.Feminino;
                    break;
                default:
                    break;
            }

            AnimalEstimacao novoAnimal = new AnimalEstimacao(nomeAnimal, idadeAnimal, especieAnimal, generoAnimal);

            Console.WriteLine("\nAnimal de estimação registado com sucesso");
            AguardarPressionarTecla();

        }

        static void RegistarCliente()
        {
            Console.WriteLine("REGISTAR CLIENTE:");

            if (AnimalEstimacao.animaisEstimacao.Count() == 0)
            {
                Console.WriteLine("\nNenhum animal de estimação registado. Por favor, registe um animal primeiro.");
                AguardarPressionarTecla();
                return;
            }

            string nomeCliente = "1";
            string emailCliente = "1";
            int contatoCliente;

            while (nomeCliente.All(char.IsDigit))
            {
                Console.Write("\nInsira o nome do cliente (não pode conter dígitos): ");
                nomeCliente = Console.ReadLine();
            }
            Console.Write("\nInsira o endereço e-mail do cliente: ");
            emailCliente = Console.ReadLine();

            while (!(new EmailAddressAttribute().IsValid(emailCliente)))
            {
                Console.WriteLine("\nENDEREÇO INVÁLIDO");
                Console.Write("Insira o endereço e-mail do cliente: ");
                emailCliente = Console.ReadLine();
            }

            Console.Write("\nInsira o número telefónico do cliente (não pode conter letras e deve ter 9 dígitos): ");
            string auxContato = Console.ReadLine();
            while (!int.TryParse(auxContato, out contatoCliente) || auxContato.Length != 9)
            {
                Console.Write("\nInsira o número telefónico do cliente (não pode conter letras e deve ter 9 dígitos): ");
                auxContato = Console.ReadLine();
            }

            Console.WriteLine("\nInsira os números dos animais de estimação que quer associar a este cliente separados por vírgulas.");

            foreach (AnimalEstimacao animal in AnimalEstimacao.animaisEstimacao)
            {
                Console.WriteLine($"{animal.ID}. {animal.Nome}, {animal.Espécie}, {animal.Idade} anos, {animal.Género}");
            }
            Console.Write("\nResposta:");
            string animaisClienteSelecionados = Console.ReadLine();
            string[] StringsIDsAnimais = animaisClienteSelecionados.Split(",");
            while (!StringsIDsAnimais.All(id => int.TryParse(id, out _)))
            {
                Console.Write($"\nPelo menos um dos valores não é um número, tente outra vez{Environment.NewLine}Resposta:");
                animaisClienteSelecionados = Console.ReadLine();
                StringsIDsAnimais = animaisClienteSelecionados.Split(",");
            }
            List<int> IDsAnimaisSelecionados = new List<int>();
            List<int> IDsAnimaisRegistados = AnimalEstimacao.animaisEstimacao.Select(animal => animal.ID).ToList();
            foreach (string  ID in StringsIDsAnimais)
            {
                if(IDsAnimaisRegistados.Contains(int.Parse(ID)))
                    IDsAnimaisSelecionados.Add(int.Parse(ID));
            }
            new Cliente(contatoCliente, emailCliente, nomeCliente, IDsAnimaisSelecionados);

            Console.WriteLine("\nCliente registado com sucesso.");
            AguardarPressionarTecla();
        }

        static void CriarServiço()
        {
            Console.WriteLine("CRIAR SERVIÇO:");
            string nome = "1";
            string medicamentos = "1";

            while (nome.All(char.IsDigit))
            {
                Console.Write("\nInsira o nome do serviço (não pode conter dígitos): ");
                nome = Console.ReadLine();
            }

            Console.Write("\nInsira o nome dos medicamentos (caso existam):");
            medicamentos = Console.ReadLine();

            Console.Write("\nInsira o preço(euros):");
            string stringPreço = Console.ReadLine();
            double preço;
            while (!double.TryParse(stringPreço, out preço))
            {
                Console.Write("\nInsira o preço(euros):");
                stringPreço = Console.ReadLine();
            }

            Console.Write("\nInsira a duração (em minutos):");
            string stringDuração = Console.ReadLine();
            int duração;
            while (!int.TryParse(stringDuração, out duração))
            {
                Console.Write("\nInsira a duração (em minutos):");
                stringPreço = Console.ReadLine();
            }

            new Servico(new TimeSpan((int)(duração/60), duração%60, 0), medicamentos, preço, nome);
            Console.WriteLine("\nServiço criado com sucesso.");
            AguardarPressionarTecla();


        }

        static void MarcarConsulta()
        {
            Console.WriteLine("MARCAR CONSULTA:");

            if (Cliente.clientes.Count() == 0)
            {
                Console.WriteLine("\nNenhum cliente registado.");
                AguardarPressionarTecla();
                return;
            }

            if (AnimalEstimacao.animaisEstimacao.Count() == 0)
            {
                Console.WriteLine("\nNão há animais de estimação registados.");
                AguardarPressionarTecla();
                return;
            }

            Console.WriteLine("\nLista de Clientes:");
            foreach (Cliente cliente in Cliente.clientes)
            {
                Console.WriteLine($"{cliente.Id} - {cliente.Nome}");
            }
            Console.Write("\nInsira o ID do cliente:");
            string stringIdClienteSelecionado = Console.ReadLine();
            int idClienteSelecionado;
            while (!int.TryParse(stringIdClienteSelecionado, out idClienteSelecionado))
            {
                Console.WriteLine("\nInsira o ID do cliente:");
                stringIdClienteSelecionado = Console.ReadLine();
            }

            var animaisEstimacaoCliente = AnimalEstimacao.animaisEstimacao.Where(animal => Cliente.clientes[idClienteSelecionado - 1].AnimaisEstimacao.Contains(animal.ID)).ToList();
            if (animaisEstimacaoCliente.Count() == 0)
            {
                Console.WriteLine("\nO cliente não tem animais de estimação.");
                AguardarPressionarTecla();
                return;
            }


            //Escolher serviço:
            Console.WriteLine("\nServiços:");
            if(Servico.servicos.Count() == 0)
            {
                Console.WriteLine("\nNenhum serviço criado.");
                AguardarPressionarTecla();
                return;
            }

            foreach(Servico service in Servico.servicos)
            {
                Console.WriteLine($"{service.Id} - {service.Nome} ({service.Preço} euros)");
            }

            Console.Write("\nEscolha o tipo de Serviço: ");
            string stringServiçoSelecionado = Console.ReadLine();
            int serviçoSelecionado;
            while (!int.TryParse(stringServiçoSelecionado, out serviçoSelecionado))
            {
                Console.WriteLine("\nEscolha o tipo de Serviço:");
                stringServiçoSelecionado = Console.ReadLine();
            }

            Período periodoSelecionado = null;

            bool HáProfissionaisDisponiveis = false;
            List<ProfissionalSaude> profissionaisDisponiveis = null;
            while (!HáProfissionaisDisponiveis)
            {
                //Escolher dia semana:
                string stringDiaSemana = "1";
                Console.WriteLine("\nEscolha o dia da semana: ");
                int indexDia = 1;
                foreach (DiaSemana diaSemana in Enum.GetValues(typeof(DiaSemana)))
                {
                    Console.WriteLine($"{indexDia} - {diaSemana}");
                    indexDia++;
                }
                Console.WriteLine("\nInsira o dia:");
                stringDiaSemana = Console.ReadLine();

                int indexDiaEscolhido;
                while (!int.TryParse(stringDiaSemana, out indexDiaEscolhido))
                {
                    Console.WriteLine("\nInsira o dia:");
                    stringDiaSemana = Console.ReadLine();
                }

                DiaSemana diaSemanaEscolhido = (DiaSemana)(indexDiaEscolhido - 1); //DIASEMANA ESCOLHIDO

                //Escolher horário:
                Console.WriteLine("\nEscolha o horário da consulta: ");
                Console.Write("Horas: ");
                string stringHora = Console.ReadLine();
                int horaEscolhida;
                while (!int.TryParse(stringHora, out horaEscolhida))
                {
                    Console.Write("Horas:");
                    stringHora = Console.ReadLine();
                }

                Console.Write("Minutos: ");
                string stringMinutos = Console.ReadLine();
                int minutosEscolhidos;
                while (!int.TryParse(stringMinutos, out minutosEscolhidos))
                {
                    Console.Write("Minutos: ");
                    stringHora = Console.ReadLine();
                }


                periodoSelecionado = new Período(diaSemanaEscolhido, new TimeSpan(horaEscolhida, minutosEscolhidos,0), Servico.servicos[serviçoSelecionado - 1].Duração);

                profissionaisDisponiveis = ProfissionalSaude.profissionaisSaude.Where(profissional => profissional.EstaDisponivel(periodoSelecionado)).ToList();

                if(profissionaisDisponiveis.Count() == 0)
                {
                    Console.WriteLine("\nNão há profissionais de saúde disponíveis nesse horário.");
                }
                else
                {
                    HáProfissionaisDisponiveis = true;
                }
            }

            foreach (ProfissionalSaude profissional in profissionaisDisponiveis)
            {
                Console.WriteLine($"{profissional.Id} - {profissional.Nome}"); 
            }
            Console.WriteLine("\nInsira o ID do profissional de saúde:");
            string stringIdProfissional = Console.ReadLine();
            int idProfissionalSelecionado;
            while (!int.TryParse(stringIdProfissional, out idProfissionalSelecionado))
            {
                Console.WriteLine("\nInsira o ID do profissional de saúde:");
                stringIdProfissional = Console.ReadLine();
            }

            foreach (ProfissionalSaude profissionalSaude in profissionaisDisponiveis)
            {
                if (profissionalSaude.Id == idProfissionalSelecionado)
                {
                    profissionalSaude.ReajustarDisponibilidade(periodoSelecionado);
                }
            }


            //Escolher animal de estimação:
            Console.WriteLine("\nEscolha o animal de estimação:");
            foreach (AnimalEstimacao animal in animaisEstimacaoCliente)
            {
                Console.WriteLine($"{animal.ID}. {animal.Nome}, {animal.Espécie}, {animal.Idade} anos, {animal.Género}");
            }

            Console.WriteLine("\nInsira o ID do animal:");
            string stringIdAnimalSelecionado = Console.ReadLine();
            int idAnimalSelecionado;
            while (!int.TryParse(stringIdAnimalSelecionado, out idAnimalSelecionado))
            {
                Console.WriteLine("\nInsira o ID do animal:");
                stringIdAnimalSelecionado = Console.ReadLine();
            }

            new Consulta(serviçoSelecionado, idProfissionalSelecionado, idAnimalSelecionado, periodoSelecionado, idClienteSelecionado);
            Console.WriteLine("\nConsulta marcada com sucesso.");
            AguardarPressionarTecla();
        }

        static void CriarRelatórioCliente()
        {
            if (Cliente.clientes.Count() == 0)
            {
                Console.WriteLine("\nNenhum cliente registado.");
                return;
            }

            Console.WriteLine("\nLista de Clientes:");
            foreach (Cliente cliente in Cliente.clientes)
            {
                Console.WriteLine($"{cliente.Id} - {cliente.Nome}");
            }
            Console.Write("\nInsira o ID do cliente:");
            string stringIdClienteSelecionado = Console.ReadLine();
            int idClienteSelecionado;
            while (!int.TryParse(stringIdClienteSelecionado, out idClienteSelecionado))
            {
                Console.WriteLine("\nInsira o ID do cliente:");
                stringIdClienteSelecionado = Console.ReadLine();
            }

            Cliente.clientes[idClienteSelecionado - 1].CriarRelatório();
            Console.WriteLine("\nRelatório criado com sucesso.");
            AguardarPressionarTecla();



        }

        static void AguardarPressionarTecla()
        {
            Console.WriteLine("Pressione qualquer tecla para continuar.");
            Console.ReadKey();
            
        }


    }
}
