using NUnit.Framework;
using ClinicaVeterinaria;
using System.Collections.Generic;
using System;
using System.Linq;
using System.IO;
using FluentAssertions;

namespace TestClinica
{
    public class ClienteTests
    {
        private ProfissionalSaude profissionalSaudeTest;
        private Cliente clienteTest;
        private AnimalEstimacao animalEstimacaoTest;

        [SetUp]
        public void Setup()
        {
            profissionalSaudeTest=new ProfissionalSaude(999999999, "aaa@gmail.com", "Rúben");
            animalEstimacaoTest = new AnimalEstimacao("Ruca", 7, "Gato", Género.Masculino);
            clienteTest = new Cliente(555555555, "bbb@gmail.com","Diego", new List<int> {animalEstimacaoTest.ID});
            Servico servicoTest = new Servico(new TimeSpan(0, 15, 0), "", 5.20, "Vacina");
            _ = new Consulta(servicoTest.Id, profissionalSaudeTest.Id, animalEstimacaoTest.ID, new Período(DiaSemana.Segunda, new TimeSpan(10, 0, 0), new TimeSpan(10, 15, 0)), clienteTest.Id);

        }


        [Test]
        public void TestRelatorioCliente()
        {
            string aux = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string dir = Path.GetFullPath(Path.Combine(aux, @"..\..\..\..\"));
            string filePath = Path.Combine(dir, $"RelatorioCliente{clienteTest.Id}.txt");
            Console.WriteLine(filePath);
            clienteTest.CriarRelatório();
            string text = System.IO.File.ReadAllText(filePath);
            string relatorio = $"RELATÓRIO - CLIENTE Nº {clienteTest.Id}" + Environment.NewLine;
            relatorio += $"Nome: {clienteTest.Nome}" + Environment.NewLine;
            relatorio += $"Frequência: {Frequência.Raramente}" + Environment.NewLine;
            relatorio += $"Número de Consultas: {1}" + Environment.NewLine;
            relatorio += "Animais de Estimação:" + Environment.NewLine;
            relatorio += $"- {animalEstimacaoTest.Nome}, {animalEstimacaoTest.Espécie}, {animalEstimacaoTest.Idade} anos, {animalEstimacaoTest.Género}" + Environment.NewLine;
            var consultasCliente = Consulta.consultas.Where(consulta => clienteTest.Id == consulta.Cliente).ToList();

            relatorio += "Serviços Prestados:"+Environment.NewLine;
            foreach (Consulta consulta in consultasCliente)
            {
                foreach (Servico servicoTest in Servico.servicos)
                {
                    if (servicoTest.Id == consulta.Servico)
                    {
                        relatorio += $"- {servicoTest.Nome}" + Environment.NewLine;
                    }
                }
            }
            text.Should().Be(relatorio);
        }
    }
}