using Confluent.Kafka;
using System.Text.Json;
using WebApiCore.Data.Entities;
using WebApiCore.Externals.Interfaces;
namespace WebApiCore.Externals
{
    public class KafkaServices:IKafkaServices
    {


        public bool Publicar(Produto produto)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };
            using var producer = new ProducerBuilder<Null, string>(config).Build();
            try
            {
                string jsonString = JsonSerializer.Serialize(produto);
                var topic = "Estoque";
                var message = new Message<Null, string> { Value = jsonString };
                producer.Produce(topic, message);
                return true;
            }
            catch (Exception)
            {

               return false;
            }
            

        }




    }
}
