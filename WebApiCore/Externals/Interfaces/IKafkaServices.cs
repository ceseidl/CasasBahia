using WebApiCore.Data.Entities;

namespace WebApiCore.Externals.Interfaces
{
    public interface IKafkaServices
    {
        bool Publicar(Produto produto);
    }
}
