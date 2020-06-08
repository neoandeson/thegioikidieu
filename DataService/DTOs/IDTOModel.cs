using System;
using System.Collections.Generic;
using System.Text;
using static DataService.Utilities.SystemEnum;

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
