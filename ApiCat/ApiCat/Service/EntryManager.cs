using ApiCat.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiCat.Service
{
	public class EntryManager
	{
		IRestService restService;

		public EntryManager(IRestService service)
		{
			restService = service;
		}

		public Task<List<CatModel>> GetTasksAsync()
		{
			return restService.GetDataAsync();
		}
		public Task DeleteTodoAsync(CatModel item)
		{
			return restService.DeleteTodoItemAsync(item);
		}
		public Task SaveItemAsync(CatModel todoItem, bool isNewItem = false)
		{
			return restService.SaveTodoItemAsync(todoItem, isNewItem);
		}
	}
}
