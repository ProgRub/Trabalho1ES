using NUnit.Framework;
using ClinicaVeterinaria;
using System;
using FluentAssertions;

namespace TestClinica
{
    public class Tests
    {
        private ProfissionalSaude profissionalSaude;
        [SetUp]
        public void Setup()
        {
            profissionalSaude=new ProfissionalSaude(999999999, "aaa@gmail.com", "Rúben");
        }

        [Test]
        public void TestVerificarDisponibilidadeProfissionaisHaProfissionalDisponivel()
        {
            Período periodoConsulta = new Período(DiaSemana.Segunda, new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0));
            ProfissionalSaude.VerificarDisponibilidadeProfissionais(periodoConsulta).Should().BeTrue();
        }

        [Test]
        public void TestVerificarDisponibilidadeProfissionaisConsultaComecaForaDePeriodoDisponibilidade()
        {
            Período periodoConsulta = new Período(DiaSemana.Segunda, new TimeSpan(05, 0, 0), new TimeSpan(11, 0, 0));
            ProfissionalSaude.VerificarDisponibilidadeProfissionais(periodoConsulta).Should().BeFalse();
        }

        [Test]
        public void TestVerificarDisponibilidadeProfissionaisConsultaAcabaForaDePeriodoDisponibilidade()
        {
            Período periodoConsulta = new Período(DiaSemana.Segunda, new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0));
            ProfissionalSaude.VerificarDisponibilidadeProfissionais(periodoConsulta).Should().BeFalse();
        }

        [Test]
        public void TestVerificarDisponibilidadeProfissionaisConsultaEstaForaDePeriodoDisponibilidade()
        {
            Período periodoConsulta = new Período(DiaSemana.Segunda, new TimeSpan(20, 0, 0), new TimeSpan(22, 0, 0));
            ProfissionalSaude.VerificarDisponibilidadeProfissionais(periodoConsulta).Should().BeFalse();
        }

        [Test]
        public void TestMarcarConsultaAMeioDePeriodoDisponibilidade()
        {
            Período periodoConsulta = new Período(DiaSemana.Segunda, new TimeSpan(11, 0, 0), new TimeSpan(12, 0, 0));
            Período periodoGerado1 = new Período(DiaSemana.Segunda, new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0));
            Período periodoGerado2 = new Período(DiaSemana.Segunda, new TimeSpan(12, 0, 0), new TimeSpan(13, 0, 0));
            profissionalSaude.ReajustarDisponibilidade(periodoConsulta);
            profissionalSaude.PeriodosDisponibilidade.Should().NotContain(periodoConsulta).And.ContainEquivalentOf(periodoGerado1).And.ContainEquivalentOf(periodoGerado2);
        }

        [Test]
        public void TestMarcarConsultaNoInicioDePeriodoDisponibilidade()
        {
            Período periodoConsulta = new Período(DiaSemana.Segunda, new TimeSpan(14, 0, 0), new TimeSpan(16, 0, 0));
            Período periodoGerado1 = new Período(DiaSemana.Segunda, new TimeSpan(16, 0, 0), new TimeSpan(17, 0, 0));
            Período periodoInexistente = new Período(DiaSemana.Segunda, new TimeSpan(14, 0, 0), new TimeSpan(14, 0, 0));
            profissionalSaude.ReajustarDisponibilidade(periodoConsulta);
            profissionalSaude.PeriodosDisponibilidade.Should().NotContain(periodoConsulta).And.ContainEquivalentOf(periodoGerado1).And.NotContain(periodoInexistente);
        }

        [Test]
        public void TestMarcarConsultaQueAcabaNoFimDePeriodoDisponibilidade()
        {
            Período periodoConsulta = new Período(DiaSemana.Segunda, new TimeSpan(12, 0, 0), new TimeSpan(13, 0, 0));
            Período periodoGerado1 = new Período(DiaSemana.Segunda, new TimeSpan(10, 0, 0), new TimeSpan(12, 0, 0));
            Período periodoInexistente = new Período(DiaSemana.Segunda, new TimeSpan(13, 0, 0), new TimeSpan(13, 0, 0));
            profissionalSaude.ReajustarDisponibilidade(periodoConsulta);
            profissionalSaude.PeriodosDisponibilidade.Should().NotContain(periodoConsulta).And.ContainEquivalentOf(periodoGerado1).And.NotContain(periodoInexistente);
        }

        [Test]
        public void TestMarcarConsultaParaAQualNaoHaVeterinarioDisponivel()
        {
            Período periodoConsulta = new Período(DiaSemana.Segunda, new TimeSpan(22, 0, 0), new TimeSpan(23, 0, 0));
            Período periodoGerado1 = new Período(DiaSemana.Segunda, new TimeSpan(10, 0, 0), new TimeSpan(13, 0, 0));
            Período periodoGerado2 = new Período(DiaSemana.Segunda, new TimeSpan(14, 0, 0), new TimeSpan(17, 0, 0));
            ProfissionalSaude.VerificarDisponibilidadeProfissionais(periodoConsulta);
            profissionalSaude.PeriodosDisponibilidade.Should().ContainEquivalentOf(periodoGerado1).And.Contain(periodoGerado2);
        }
    }
}