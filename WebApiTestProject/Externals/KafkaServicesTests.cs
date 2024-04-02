using Moq;
using System;
using WebApiCore.Data.Entities;
using WebApiCore.Externals;
using Xunit;

namespace WebApiTestProject.Externals
{
    public class KafkaServicesTests
    {
        private MockRepository mockRepository;



        public KafkaServicesTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private KafkaServices CreateKafkaServices()
        {
            return new KafkaServices();
        }

        [Fact]
        public void Publicar_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var kafkaServices = this.CreateKafkaServices();
            Produto produto = null;

            // Act
            var result = kafkaServices.Publicar(
                produto);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
