using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApiCat.Model;

namespace ApiCat.Service
{
    public interface IRestService
    {
        Task<List<CatModel>> GetDataAsync();
        Task SaveTodoItemAsync(CatModel item, bool isNewItem);
        Task DeleteTodoItemAsync(CatModel item);
    }
}
