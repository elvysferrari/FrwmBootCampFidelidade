using FrwkBootCampFidelidade.Core.RabbitMq;

namespace FrwkBootCampFidelidade.Aplicacao.Interfaces.RpcService
{
    public interface IRpcClientService
    {
        string Call(MessageInputModel message);
        void Close();
    }
}
