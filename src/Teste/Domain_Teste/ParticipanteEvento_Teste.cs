using Domain;
using Domain.DomainObjects;
using System;
using Xunit;

namespace Domain_Teste
{
    public class ParticipanteEvento_Teste
    {
        [Fact]
        public void Construtor_ValorComidaMenorQueVinteComConvidado_RetornaErro()
        {
            // Arrange &  Act
            var exception = Assert.Throws<DomainException>(() =>
                                   new ParticipanteEvento
                                   (
                                       eventoId: Guid.NewGuid(),
                                       funcionarioId: Guid.NewGuid(),
                                       convidadoId: Guid.NewGuid(),
                                       valorComida: 19,
                                       valorBebida: 0,
                                       convidadoComBebida: false,
                                       funcionarioComBebida: false
                                    ));
            //Assert
            Assert.Equal("Valor da comida não pode ser menor que 20 reais, pois está levando um convidado.", exception.Message);
        }

        [Fact]
        public void Construtor_ValorComidaMenorQueDezSemConvidado_RetornaErro()
        {
            // Arrange &  Act
            var exception = Assert.Throws<DomainException>(() =>
                                   new ParticipanteEvento
                                   (
                                       eventoId: Guid.NewGuid(),
                                       funcionarioId: Guid.NewGuid(),
                                       convidadoId: null,
                                       valorComida: 9,
                                       valorBebida: 0,
                                       convidadoComBebida: false,
                                       funcionarioComBebida: false
                                    ));
            //Assert
            Assert.Equal("Valor da comida não pode ser menor que 10 reais.", exception.Message);
        }

        [Fact]
        public void Construtor_FuncionarioEConvidacoComBebidaEValorBebidaMenorQueVinte_RetornaErro()
        {
            // Arrange &  Act
            var exception = Assert.Throws<DomainException>(() =>
                                        new ParticipanteEvento
                                        (
                                            eventoId: Guid.NewGuid(),
                                            funcionarioId: Guid.NewGuid(),
                                            convidadoId: Guid.NewGuid(),
                                            valorComida: 20,
                                            valorBebida: 19,
                                            convidadoComBebida: true,
                                            funcionarioComBebida: true
                                         ));

            Assert.Equal("Valor da bebida não pode ser menor que 20 reais, pois os dois irão beber.", exception.Message);
        }

        [Fact]
        public void Construtor_FuncionarioComBebidaEValorBebidaMenorQueDez_RetornaErro()
        {
            // Arrange &  Act
            var exception = Assert.Throws<DomainException>(() =>
                                        new ParticipanteEvento
                                        (
                                            eventoId: Guid.NewGuid(),
                                            funcionarioId: Guid.NewGuid(),
                                            convidadoId: Guid.NewGuid(),
                                            valorComida: 20,
                                            valorBebida: 9,
                                            convidadoComBebida: false,
                                            funcionarioComBebida: true
                                         ));
            //Assert
            Assert.Equal("Valor da bebida não pode ser menor que 10 reais, pois o funcionario irá beber.", exception.Message);
        }

        [Fact]
        public void Construtor_ConvidadoComBebidaEValorBebidaMenorQueDez_RetornaErro()
        {
            // Arrange &  Act
            var exception = Assert.Throws<DomainException>(() =>
                                        new ParticipanteEvento
                                        (
                                            eventoId: Guid.NewGuid(),
                                            funcionarioId: Guid.NewGuid(),
                                            convidadoId: Guid.NewGuid(),
                                            valorComida: 20,
                                            valorBebida: 9,
                                            convidadoComBebida: true,
                                            funcionarioComBebida: false
                                         ));
            //Assert
            Assert.Equal("Valor da bebida não pode ser menor que 10 reais, pois o convidado irá beber.", exception.Message);

        }

        [Fact]
        public void Construtor_InserindoValoresValidos_RetornaSucesso()
        {
            // Arrange &  Act
            var comConvidao = new ParticipanteEvento
                                    (
                                        eventoId: Guid.NewGuid(),
                                        funcionarioId: Guid.NewGuid(),
                                        convidadoId: Guid.NewGuid(),
                                        valorComida: 20,
                                        valorBebida: 20,
                                        convidadoComBebida: true,
                                        funcionarioComBebida: true
                                     );

            var comConvidaoSemBebida = new ParticipanteEvento
                              (
                                  eventoId: Guid.NewGuid(),
                                  funcionarioId: Guid.NewGuid(),
                                  convidadoId: Guid.NewGuid(),
                                  valorComida: 20,
                                  valorBebida: 0,
                                  convidadoComBebida: false,
                                  funcionarioComBebida: false
                               );

            var apenasConvidadoComBebida = new ParticipanteEvento
                         (
                             eventoId: Guid.NewGuid(),
                             funcionarioId: Guid.NewGuid(),
                             convidadoId: Guid.NewGuid(),
                             valorComida: 20,
                             valorBebida: 10,
                             convidadoComBebida: true,
                             funcionarioComBebida: false
                          );

            var apenasFuncionarioComBebida = new ParticipanteEvento
                       (
                           eventoId: Guid.NewGuid(),
                           funcionarioId: Guid.NewGuid(),
                           convidadoId: Guid.NewGuid(),
                           valorComida: 20,
                           valorBebida: 10,
                           convidadoComBebida: false,
                           funcionarioComBebida: true
                        );

            var semConvidado = new ParticipanteEvento
                                    (
                                        eventoId: Guid.NewGuid(),
                                        funcionarioId: Guid.NewGuid(),
                                        convidadoId: null,
                                        valorComida: 10,
                                        valorBebida: 0,
                                        convidadoComBebida: false,
                                        funcionarioComBebida: false
                                     );

            var semConvidadoComBebida = new ParticipanteEvento
                                    (
                                        eventoId: Guid.NewGuid(),
                                        funcionarioId: Guid.NewGuid(),
                                        convidadoId: null,
                                        valorComida: 10,
                                        valorBebida: 10,
                                        convidadoComBebida: true,
                                        funcionarioComBebida: false
                                     );

            //Assert
            Assert.NotNull(comConvidao);
            Assert.NotNull(comConvidaoSemBebida);
            Assert.NotNull(apenasConvidadoComBebida);
            Assert.NotNull(apenasFuncionarioComBebida);
            Assert.NotNull(semConvidado);
            Assert.NotNull(semConvidadoComBebida);
        }

        [Fact]
        public void RemoverConvidado_InserindoValoresValidos_RetornaSucesso()
        {
            // Arrange 
            var osDoisBebendo = new ParticipanteEvento
                                    (
                                        eventoId: Guid.NewGuid(),
                                        funcionarioId: Guid.NewGuid(),
                                        convidadoId: Guid.NewGuid(),
                                        valorComida: 20,
                                        valorBebida: 20,
                                        convidadoComBebida: true,
                                        funcionarioComBebida: true
                                     );

            var convidadoBebendo = new ParticipanteEvento
                                   (
                                       eventoId: Guid.NewGuid(),
                                       funcionarioId: Guid.NewGuid(),
                                       convidadoId: Guid.NewGuid(),
                                       valorComida: 20,
                                       valorBebida: 10,
                                       convidadoComBebida: true,
                                       funcionarioComBebida: false
                                    );

            var funcionarioBebendo = new ParticipanteEvento
                               (
                                   eventoId: Guid.NewGuid(),
                                   funcionarioId: Guid.NewGuid(),
                                   convidadoId: Guid.NewGuid(),
                                   valorComida: 20,
                                   valorBebida: 10,
                                   convidadoComBebida: false,
                                   funcionarioComBebida: true
                                );

            // Act
            osDoisBebendo.RemoverConvidado();
            convidadoBebendo.RemoverConvidado();
            funcionarioBebendo.RemoverConvidado();


            //Assert
            Assert.True(osDoisBebendo.ConvidadoId == null && osDoisBebendo.ValorComida == 10 && osDoisBebendo.ValorBebida == 10);
            Assert.True(convidadoBebendo.ConvidadoId == null && convidadoBebendo.ValorComida == 10 && convidadoBebendo.ValorBebida == 0);
            Assert.True(funcionarioBebendo.ConvidadoId == null && funcionarioBebendo.ValorComida == 10 && funcionarioBebendo.ValorBebida == 10);
        }
    }
}
