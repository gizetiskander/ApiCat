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

		public Task<List<CountModel>> GetTasksAsync()
		{
			return restService.GetDataAsync();
		}
	}
}
