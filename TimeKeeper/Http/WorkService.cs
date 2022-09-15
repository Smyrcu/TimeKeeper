using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TimeKeeper.Exceptions;
using TimeKeeper.Models;

namespace TimeKeeper.Http
{
    public interface IWorkService
    {
        List<WorkDayModel> GetWorkList(int id);
    }

    public class WorkService : IWorkService
    {
        private readonly ApiConstants _constants;
        private readonly User _user;

        public WorkService(User user)
        {
            _user = user;
            _constants = new ApiConstants();
        }

        public List<WorkDayModel> GetWorkList(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri(_constants.GetWorkTimeGet(3));
                
                var jsonString = client.GetAsync(uri).Result.Content.ReadAsStringAsync().Result;
                if (jsonString is "Something went wrong")
                    throw new CustomException("Something went wrong");
                var result = JsonSerializer.Deserialize<List<WorkDayModel>>(jsonString);
                return result;
            }
        }
    }
}
