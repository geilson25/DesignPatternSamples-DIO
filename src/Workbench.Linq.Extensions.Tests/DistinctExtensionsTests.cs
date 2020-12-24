using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Workbench.Linq.Extensions.Tests
{
    public class DistinctExtensionsTests
    {
        private struct PessoaFisica
        {
            public string Nome { get; set; }
            public string NomeMae { get; set; }
            public string CPF { get; set; }
        }

        [Fact(DisplayName = "Data uma cole��o com 3 objetos sendo 2 iguais ent�o o DISTINCT com uma compara��o simples deve retornar uma lista com 2 objetos.")]
        public void ListagemComItensRepetidosComparecaoSimples()
        {
            //Arrange
            IEnumerable<PessoaFisica> pessoas = new List<PessoaFisica>()
            {
                new PessoaFisica() { Nome = "Victor Fructuoso", NomeMae = "Ana", CPF = "111.111.111-11" },
                new PessoaFisica() { Nome = "Victor Fructuoso", NomeMae = "Paula", CPF = "111.111.111-11" },
                new PessoaFisica() { Nome = "Victor Fructuoso", NomeMae = "Ana", CPF = "222.222.222-22" }
            };

            
            //Act
            IEnumerable<PessoaFisica> pessoasDiferentes = pessoas.Distinct(p => p.CPF);

            //Assert
            Assert.NotNull(pessoasDiferentes);
            Assert.True(pessoasDiferentes.Any());
            Assert.Equal(2, pessoasDiferentes.Count());
            Assert.DoesNotContain(pessoasDiferentes, p => p.NomeMae == "Paula");
        }

        [Fact(DisplayName = "Data uma cole��o com 3 objetos sendo 2 iguais ent�o o DISTINCT com uma compara��o composta deve retornar uma lista com 2 objetos.")]
        public void ListagemComItensRepetidosComparecaoComposta()
        {
            IEnumerable<PessoaFisica> pessoas = new List<PessoaFisica>()
            {
                new PessoaFisica() { Nome = "Victor Fructuoso", NomeMae = "Ana", CPF = "111.111.111-11" },
                new PessoaFisica() { Nome = "Victor Fructuoso", NomeMae = "Paula", CPF = "111.111.111-11" },
                new PessoaFisica() { Nome = "Victor Fructuoso", NomeMae = "Ana", CPF = "222.222.222-22" }
            };

            IEnumerable<PessoaFisica> pessoasDiferentes = pessoas.Distinct(p => new { p.Nome, p.NomeMae });

            Assert.NotNull(pessoasDiferentes);
            Assert.True(pessoasDiferentes.Any());
            Assert.Equal(2, pessoasDiferentes.Count());
            Assert.DoesNotContain(pessoasDiferentes, p => p.CPF == "222.222.222-22");
        }
    }
}
