using System.Threading.Tasks;
using Web.BootCampFidelidade.HttpAggregator.Models;
using Web.BootCampFidelidade.HttpAggregator.Models.DTO;

namespace Web.BootCampFidelidade.HttpAggregator.Service.Interface
{
    public interface IRabbitMqService
    {
        string Call(MessageInputModel message);
        void Close();
    }
}
