using Moq;
using System;
using System.Threading.Tasks;
using WebApiCore.Data;
using WebApiCore.Data.Entities;
using WebApiCore.Externals.Interfaces;
using WebApiCore.Repositories;
using Xunit;

namespace WebApiTestProject.Repositories
{
    public class ProdutoRepositoryTests
    {
        private MockRepository mockRepository;

        private Mock<ApplicationDbContext> mockApplicationDbContext;
        private Mock<IKafkaServices> mockKafkaServices;

        public ProdutoRepositoryTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockApplicationDbContext = this.mockRepository.Create<ApplicationDbContext>();
            this.mockKafkaServices = this.mockRepository.Create<IKafkaServices>();
        }

        private ProdutoRepository CreateProdutoRepository()
        {
            return new ProdutoRepository(
                this.mockApplicationDbContext.Object,
                this.mockKafkaServices.Object);
        }

        [Fact]
        public async Task GetProduto_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var produtoRepository = this.CreateProdutoRepository();

            // Act
            var result = await produtoRepository.GetProduto();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task PutProduto_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var produtoRepository = this.CreateProdutoRepository();
            int id = 0;
            Produto produto = null;

            // Act
            var result = await produtoRepository.PutProduto(
                id,
                produto);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task PostProduto_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var produtoRepository = this.CreateProdutoRepository();
            Produto produto = null;

            // Act
            var result = await produtoRepository.PostProduto(
                produto);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task DeleteProduto_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var produtoRepository = this.CreateProdutoRepository();
            int id = 0;

            // Act
            var result = await produtoRepository.DeleteProduto(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetProduto_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var produtoRepository = this.CreateProdutoRepository();
            int id = 0;

            // Act
            var result = await produtoRepository.GetProduto(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
