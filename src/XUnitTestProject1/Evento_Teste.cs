using Domain;
using Domain.DomainObjects;
using System;
using Xunit;

namespace Domain_Teste
{
    public class Evento_Teste
    {
        [Fact]
        public void Construtor_InserindoDescricaoInvalida_RetornaErro()
        {
            // Arrange &  Act
            var decVazia = Assert.Throws<DomainException>(() =>
                                   new Evento
                                   (
                                       descricao: "",
                                       data: DateTime.Now,
                                       custoComida: 0,
                                       custoBebida: 0
                                    ));
            var descNula = Assert.Throws<DomainException>(() =>
                                          new Evento
                                          (
                                              descricao: null,
                                              data: DateTime.Now,
                                              custoComida: 0,
                                              custoBebida: 0
                                           ));
            //Assert
            Assert.Equal("O campo Descricao não pode estar vazio.", decVazia.Message);
            Assert.Equal("O campo Descricao não pode estar vazio.", descNula.Message);
        }

        [Fact]
        public void Construtor_InserindoDataInvalida_RetornaErro()
        {
            // Arrange &  Act

            //Testando com data anterior a hoje.
            var exception = Assert.Throws<DomainException>(() =>
                                   new Evento
                                   (
                                       descricao: "Teste Data Invalida",
                                       data: DateTime.Now.AddDays(-1),
                                       custoComida: 0,
                                       custoBebida: 0
                                    ));
            //Assert
            Assert.Equal("Data do evento não pode ser menor que a data atual.", exception.Message);
        }

        [Fact]
        public void Construtor_InserindoCustoComidaInvalido_RetornaErro()
        {
            // Arrange &  Act
            var exception = Assert.Throws<DomainException>(() =>
                                   new Evento
                                   (
                                       descricao: "Teste CustoComida inválido. ",
                                       data: DateTime.Now,
                                       custoComida: -10,
                                       custoBebida: 0
                                    ));
            //Assert
            Assert.Equal("O campo CustoComida não pode ser menor que zero.", exception.Message);
        }

        [Fact]
        public void Construtor_InserindoCustoBebidaInvalido_RetornaErro()
        {
            // Arrange &  Act
            var exception = Assert.Throws<DomainException>(() =>
                                   new Evento
                                   (
                                       descricao: "Teste custo bebida inválido",
                                       data: DateTime.Now,
                                       custoComida: 0,
                                       custoBebida: -10
                                    ));
            //Assert
            Assert.Equal("O campo CustoBebida não pode ser menor que zero.", exception.Message);
        }

        [Fact]
        public void Construtor_InserindoValoresValidos_RetornaSucesso()
        {
            // Arrange &  Act
            var evento = new Evento
                                (
                                    descricao: "Teste custo bebida inválido",
                                    data: DateTime.Now,
                                    custoComida: 100,
                                    custoBebida: 100
                                );
            //Assert
            Assert.NotNull(evento);
        }

    }
}
