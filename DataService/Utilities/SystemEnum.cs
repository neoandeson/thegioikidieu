using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Utilities
{
    public static class SystemEnum
    {
        public static class ResponseCode
        {
            public static int Success = 200;
            public static int BadRequest = 400;
            public static int Unauthorized = 401;
            public static int Fobidden = 403;
            public static int Conflict = 409;
            public static int InternalServerError = 500;
        }

    }
}
