using NUnit.Framework;
using ClinicaVeterinaria;
using System.Collections.Generic;
using System;
using System.Linq;
using System.IO;
using FluentAssertions;

namespace TestClinica
{
    public class Tests
    {
        private ProfissionalSaude profissionalSaude;
        private Cliente cliente;
        private AnimalEstimacao animalEstimacao;
        private Consulta consulta;
        [SetUp]
        public void Setup()
        {
            profissionalSaude=new ProfissionalSaude(999999999, "aaa@gmail.com", "R�ben");
            animalEstimacao = new AnimalEstimacao("Ruca", 7, "Gato", G�nero.Masculino);
            cliente = new Cliente(555555555, "bbb@gmail.com","Diego", new List<int> {1 });
            Servico servico = new Servico(new TimeSpan(0, 15, 0), "", 5.20, "Vacina");
            consulta = new Consulta(1, 1, 1, new Per�odo(DiaSemana.Segunda, new TimeSpan(10, 0, 0), new TimeSpan(10, 15, 0)), 1);

        }

        [Test]
        public void TestVerificarDisponibilidadeProfissionaisHaProfissionalDisponivel()
        {
            Per�odo periodoConsulta = new Per�odo(DiaSemana.Segunda, new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0));
            ProfissionalSaude.VerificarDisponibilidadeProfissionais(periodoConsulta).Should().BeTrue();
        }

        [Test]
        public void TestVerificarDisponibilidadeProfissionaisConsultaComecaForaDePeriodoDisponibilidade()
        {
            Per�odo periodoConsulta = new Per�odo(DiaSemana.Segunda, new TimeSpan(05, 0, 0), new TimeSpan(11, 0, 0));
            ProfissionalSaude.VerificarDisponibilidadeProfissionais(periodoConsulta).Should().BeFalse();
        }

        [Test]
        public void TestVerificarDisponibilidadeProfissionaisConsultaAcabaForaDePeriodoDisponibilidade()
        {
            Per�odo periodoConsulta = new Per�odo(DiaSemana.Segunda, new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0));
            ProfissionalSaude.VerificarDisponibilidadeProfissionais(periodoConsulta).Should().BeFalse();
        }

        [Test]
        public void TestVerificarDisponibilidadeProfissionaisConsultaEstaForaDePeriodoDisponibilidade()
        {
            Per�odo periodoConsulta = new Per�odo(DiaSemana.Segunda, new TimeSpan(20, 0, 0), new TimeSpan(22, 0, 0));
            ProfissionalSaude.VerificarDisponibilidadeProfissionais(periodoConsulta).Should().BeFalse();
        }

        [Test]
        public void TestMarcarConsultaAMeioDePeriodoDisponibilidade()
        {
            Per�odo periodoConsulta = new Per�odo(DiaSemana.Segunda, new TimeSpan(11, 0, 0), new TimeSpan(12, 0, 0));
            Per�odo periodoGerado1 = new Per�odo(DiaSemana.Segunda, new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0));
            Per�odo periodoGerado2 = new Per�odo(DiaSemana.Segunda, new TimeSpan(12, 0, 0), new TimeSpan(13, 0, 0));
            profissionalSaude.ReajustarDisponibilidade(periodoConsulta);
            profissionalSaude.PeriodosDisponibilidade.Should().NotContain(periodoConsulta).And.ContainEquivalentOf(periodoGerado1).And.ContainEquivalentOf(periodoGerado2);
        }

        [Test]
        public void TestMarcarConsultaNoInicioDePeriodoDisponibilidade()
        {
            Per�odo periodoConsulta = new Per�odo(DiaSemana.Segunda, new TimeSpan(14, 0, 0), new TimeSpan(16, 0, 0));
            Per�odo periodoGerado1 = new Per�odo(DiaSemana.Segunda, new TimeSpan(16, 0, 0), new TimeSpan(17, 0, 0));
            Per�odo periodoInexistente = new Per�odo(DiaSemana.Segunda, new TimeSpan(14, 0, 0), new TimeSpan(14, 0, 0));
            profissionalSaude.ReajustarDisponibilidade(periodoConsulta);
            profissionalSaude.PeriodosDisponibilidade.Should().NotContain(periodoConsulta).And.ContainEquivalentOf(periodoGerado1).And.NotContain(periodoInexistente);
        }

        [Test]
        public void TestMarcarConsultaQueAcabaNoFimDePeriodoDisponibilidade()
        {
            Per�odo periodoConsulta = new Per�odo(DiaSemana.Segunda, new TimeSpan(12, 0, 0), new TimeSpan(13, 0, 0));
            Per�odo periodoGerado1 = new Per�odo(DiaSemana.Segunda, new TimeSpan(10, 0, 0), new TimeSpan(12, 0, 0));
            Per�odo periodoInexistente = new Per�odo(DiaSemana.Segunda, new TimeSpan(13, 0, 0), new TimeSpan(13, 0, 0));
            profissionalSaude.ReajustarDisponibilidade(periodoConsulta);
            profissionalSaude.PeriodosDisponibilidade.Should().NotContain(periodoConsulta).And.ContainEquivalentOf(periodoGerado1).And.NotContain(periodoInexistente);
        }

        [Test]
        public void TestMarcarConsultaParaAQualNaoHaVeterinarioDisponivel()
        {
            Per�odo periodoConsulta = new Per�odo(DiaSemana.Segunda, new TimeSpan(22, 0, 0), new TimeSpan(23, 0, 0));
            Per�odo periodoGerado1 = new Per�odo(DiaSemana.Segunda, new TimeSpan(10, 0, 0), new TimeSpan(13, 0, 0));
            Per�odo periodoGerado2 = new Per�odo(DiaSemana.Segunda, new TimeSpan(14, 0, 0), new TimeSpan(17, 0, 0));
            ProfissionalSaude.VerificarDisponibilidadeProfissionais(periodoConsulta);
            profissionalSaude.PeriodosDisponibilidade.Should().ContainEquivalentOf(periodoGerado1).And.ContainEquivalentOf(periodoGerado2);
        }

        [Test]
        public void TestRelatorioCliente()
        {
            string aux = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string dir = Path.GetFullPath(Path.Combine(aux, @"..\..\..\..\"));
            string filePath = Path.Combine(dir, "RelatorioCliente1.txt");
            Console.WriteLine(filePath);
            cliente.criarRelat�rio();
            string text = System.IO.File.ReadAllText(filePath);
            string relatorio = $"RELAT�RIO - CLIENTE N� {cliente.Id}\n";
            relatorio += $"Nome: {cliente.Nome}\n";
            relatorio += $"Frequ�ncia: {Frequ�ncia.Raramente}\n";
            relatorio += $"N�mero de Consultas: {1}\n";
                relatorio += $"- {animalEstimacao.Nome}, {animalEstimacao.Esp�cie}, {animalEstimacao.Idade} anos, {animalEstimacao.G�nero}\n";
            var consultasCliente = Consulta.consultas.Where(consulta => cliente.Id == consulta.Cliente).ToList();

            foreach (Consulta consulta in consultasCliente)
            {
                foreach (Servico servico in Servico.servicos)
                {
                    if (servico.Id == consulta.Servico)
                    {
                        relatorio += $"- {servico.Nome}";
                    }
                }
            }
            text.Should().Be(relatorio);
        }
    }
}