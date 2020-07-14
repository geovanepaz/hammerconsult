using Domain;
using Domain.DomainObjects;
using Xunit;

namespace Domain_Teste
{
    public class Funcionario_Teste
    {
        [Fact]
        public void Construtor_InserindoNomeInvalido_RetornaErro()
        {
            // Arrange &  Act
            var exception = Assert.Throws<DomainException>(() =>
                                   new Funcionario
                                   (
                                       nome: "",
                                       email: "geovane@gmail.com",
                                       cargo: "Dev .Net",
                                       setor: "TI"
                                    ));
            //Assert
            Assert.Equal("O campo Nome não pode estar vazio.", exception.Message);
        }

        [Fact]
        public void Construtor_InserindoEmailInvalido_RetornaErro()
        {
            // Arrange &  Act
            var exception = Assert.Throws<DomainException>(() =>
                                   new Funcionario
                                   (
                                       nome: "Geovane",
                                       email: "",
                                       cargo: "Dev .Net",
                                       setor: "TI"
                                    ));
            //Assert
            Assert.Equal("O campo Nome não pode estar vazio.", exception.Message);
        }

        [Fact]
        public void Construtor_InserindoCargoInvalido_RetornaErro()
        {
            // Arrange &  Act
            var exception = Assert.Throws<DomainException>(() =>
                                   new Funcionario
                                   (
                                       nome: "Geovane",
                                       email: "geovane@gmail.com",
                                       cargo: "",
                                       setor: "TI"
                                    ));
            //Assert
            Assert.Equal("O campo Nome não pode estar vazio.", exception.Message);
        }

        [Fact]
        public void Construtor_InserindoSetorInvalido_RetornaErro()
        {
            // Arrange &  Act
            var exception = Assert.Throws<DomainException>(() =>
                                   new Funcionario
                                   (
                                       nome: "",
                                       email: "geovane@gmail.com",
                                       cargo: "Dev .Net",
                                       setor: ""
                                    ));
            //Assert
            Assert.Equal("O campo Nome não pode estar vazio.", exception.Message);
        }

        [Fact]
        public void Construtor_InserindoValoresValidos_RetornaSucesso()
        {
            // Arrange &  Act
            var funcionario = new Funcionario
                                   (
                                       nome: "Geovane",
                                       email: "geovane@gmail.com",
                                       cargo: "Dev .Net",
                                       setor: "TI"
                                    );
            //Assert
            Assert.NotNull(funcionario);
        }
    }
}
