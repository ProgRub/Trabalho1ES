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
            profissionalSaudeTest=new ProfissionalSaude(999999999, "aaa@gmail.com", "R�ben");
            animalEstimacaoTest = new AnimalEstimacao("Ruca", 7, "Gato", G�nero.Masculino);
            clienteTest = new Cliente(555555555, "bbb@gmail.com","Diego", new List<int> {animalEstimacaoTest.ID});
            Servico servicoTest = new Servico(new TimeSpan(0, 15, 0), "", 5.20, "Vacina");
            _ = new Consulta(servicoTest.Id, profissionalSaudeTest.Id, animalEstimacaoTest.ID, new Per�odo(DiaSemana.Segunda, new TimeSpan(10, 0, 0), new TimeSpan(10, 15, 0)), clienteTest.Id);

        }


        [Test]
        public void TestRelatorioCliente()
        {
            string aux = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string dir = Path.GetFullPath(Path.Combine(aux, @"..\..\..\..\"));
            string filePath = Path.Combine(dir, $"RelatorioCliente{clienteTest.Id}.txt");
            Console.WriteLine(filePath);
            clienteTest.CriarRelat�rio();
            string text = System.IO.File.ReadAllText(filePath);
            string relatorio = $"RELAT�RIO - CLIENTE N� {clienteTest.Id}" + Environment.NewLine;
            relatorio += $"Nome: {clienteTest.Nome}" + Environment.NewLine;
            relatorio += $"Frequ�ncia: {Frequ�ncia.Raramente}" + Environment.NewLine;
            relatorio += $"N�mero de Consultas: {1}" + Environment.NewLine;
            relatorio += "Animais de Estima��o:" + Environment.NewLine;
            relatorio += $"- {animalEstimacaoTest.Nome}, {animalEstimacaoTest.Esp�cie}, {animalEstimacaoTest.Idade} anos, {animalEstimacaoTest.G�nero}" + Environment.NewLine;
            var consultasCliente = Consulta.consultas.Where(consulta => clienteTest.Id == consulta.Cliente).ToList();

            relatorio += "Servi�os Prestados:"+Environment.NewLine;
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