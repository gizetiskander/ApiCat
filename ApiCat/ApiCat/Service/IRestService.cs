using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApiCat.Model;

namespace ApiCat.Service
{
    public interface IRestService
    {
        Task<List<CountModel>> GetDataAsync();
    }
}
