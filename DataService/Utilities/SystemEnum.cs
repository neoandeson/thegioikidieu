using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Utilities
{
    public static class SystemEnum
    {
        public static class RecordStatus
        {
            public static int Active = 1;
            public static int Deactive = 0;
            public static int Deleted = -1;
        }

        public static class ResponseCode
        {
            public static int Success = 200;
            public static int BadRequest = 400;
            public static int Unauthorized = 401;
            public static int Fobidden = 403;
            public static int Conflict = 409;
            public static int InternalServerError = 500;
        }

        public static class Role
        {
            public const string Admin = "Admin";
            public const string User = "User";
        }
    }
}
