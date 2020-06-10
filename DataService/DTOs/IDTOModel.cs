
namespace DataService.DTOs
{
    public interface IRequestModel<DTO, Entity>
    {
        Entity MapToEntity();
    }

    public abstract class IResponseModel {
        public int ResponseCode;
    }
}
