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
            profissionalSaude=new ProfissionalSaude(999999999, "aaa@gmail.com", "R�ben");
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
            profissionalSaude.PeriodosDisponibilidade.Should().ContainEquivalentOf(periodoGerado1).And.Contain(periodoGerado2);
        }
    }
}