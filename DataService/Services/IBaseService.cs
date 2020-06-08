using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Services
{
    public interface IAsyncBaseService<Rq, Rs>
    {
        Task<Rs> Execute(Rq rq);
    }

    public interface IBaseService<Rq, Rs>
    {
        Rs Execute(Rq rq);
    }
}
