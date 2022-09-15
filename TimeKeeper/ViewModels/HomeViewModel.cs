using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Windows.Documents;
using System.Windows.Forms.VisualStyles;
using TimeKeeper.Http;
using TimeKeeper.Models;

namespace TimeKeeper.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {

        //Fields
        private string _title;
        private string _value;
        private List<WorkDayModel> _workDays;
        private List<WorkDayDisplayModel> _display;
        private IUserService _userService;
        private IWorkService _workService;

        private string dev =
            "[{\"id\":1,\"workerId\":3,\"workTime\":8,\"date\":\"2022-08-01T00:00:00\",\"ordersDone\":200,\"shopsDone\":1},{\"id\":2,\"workerId\":3,\"workTime\":8,\"date\":\"2022-08-02T00:00:00\",\"ordersDone\":251,\"shopsDone\":0},{\"id\":3,\"workerId\":3,\"workTime\":8,\"date\":\"2022-08-03T00:00:00\",\"ordersDone\":221,\"shopsDone\":0},{\"id\":4,\"workerId\":3,\"workTime\":8,\"date\":\"2022-08-04T00:00:00\",\"ordersDone\":140,\"shopsDone\":3},{\"id\":5,\"workerId\":3,\"workTime\":8,\"date\":\"2022-08-05T00:00:00\",\"ordersDone\":186,\"shopsDone\":0},{\"id\":6,\"workerId\":3,\"workTime\":7,\"date\":\"2022-08-06T00:00:00\",\"ordersDone\":174,\"shopsDone\":1},{\"id\":7,\"workerId\":3,\"workTime\":6,\"date\":\"2022-08-07T00:00:00\",\"ordersDone\":101,\"shopsDone\":5},{\"id\":8,\"workerId\":3,\"workTime\":4,\"date\":\"2022-08-08T00:00:00\",\"ordersDone\":54,\"shopsDone\":8},{\"id\":9,\"workerId\":3,\"workTime\":8,\"date\":\"2022-08-09T00:00:00\",\"ordersDone\":170,\"shopsDone\":2},{\"id\":10,\"workerId\":3,\"workTime\":5,\"date\":\"2022-08-10T00:00:00\",\"ordersDone\":112,\"shopsDone\":4},{\"id\":11,\"workerId\":3,\"workTime\":5,\"date\":\"2022-08-11T00:00:00\",\"ordersDone\":24,\"shopsDone\":7},{\"id\":12,\"workerId\":3,\"workTime\":9,\"date\":\"2022-08-12T00:00:00\",\"ordersDone\":0,\"shopsDone\":21},{\"id\":13,\"workerId\":3,\"workTime\":8,\"date\":\"2022-08-13T00:00:00\",\"ordersDone\":18,\"shopsDone\":18},{\"id\":14,\"workerId\":3,\"workTime\":8,\"date\":\"2022-08-14T00:00:00\",\"ordersDone\":174,\"shopsDone\":1},{\"id\":15,\"workerId\":3,\"workTime\":8,\"date\":\"2022-08-15T00:00:00\",\"ordersDone\":201,\"shopsDone\":1},{\"id\":16,\"workerId\":3,\"workTime\":8,\"date\":\"2022-08-16T00:00:00\",\"ordersDone\":173,\"shopsDone\":3},{\"id\":17,\"workerId\":3,\"workTime\":8,\"date\":\"2022-08-17T00:00:00\",\"ordersDone\":124,\"shopsDone\":4},{\"id\":18,\"workerId\":3,\"workTime\":7,\"date\":\"2022-08-18T00:00:00\",\"ordersDone\":117,\"shopsDone\":3},{\"id\":19,\"workerId\":3,\"workTime\":6,\"date\":\"2022-08-19T00:00:00\",\"ordersDone\":127,\"shopsDone\":0},{\"id\":20,\"workerId\":3,\"workTime\":6,\"date\":\"2022-08-20T00:00:00\",\"ordersDone\":127,\"shopsDone\":1},{\"id\":21,\"workerId\":3,\"workTime\":6,\"date\":\"2022-08-21T00:00:00\",\"ordersDone\":121,\"shopsDone\":0},{\"id\":22,\"workerId\":3,\"workTime\":7,\"date\":\"2022-08-22T00:00:00\",\"ordersDone\":186,\"shopsDone\":0},{\"id\":23,\"workerId\":3,\"workTime\":6,\"date\":\"2022-08-23T00:00:00\",\"ordersDone\":192,\"shopsDone\":0},{\"id\":24,\"workerId\":3,\"workTime\":8,\"date\":\"2022-08-24T00:00:00\",\"ordersDone\":125,\"shopsDone\":4},{\"id\":25,\"workerId\":3,\"workTime\":8,\"date\":\"2022-08-25T00:00:00\",\"ordersDone\":148,\"shopsDone\":5},{\"id\":26,\"workerId\":3,\"workTime\":8,\"date\":\"2022-08-26T00:00:00\",\"ordersDone\":146,\"shopsDone\":1},{\"id\":27,\"workerId\":3,\"workTime\":6,\"date\":\"2022-08-27T00:00:00\",\"ordersDone\":120,\"shopsDone\":0},{\"id\":28,\"workerId\":3,\"workTime\":6,\"date\":\"2022-08-28T00:00:00\",\"ordersDone\":97,\"shopsDone\":5},{\"id\":29,\"workerId\":3,\"workTime\":10,\"date\":\"2022-08-29T00:00:00\",\"ordersDone\":248,\"shopsDone\":0},{\"id\":30,\"workerId\":3,\"workTime\":4,\"date\":\"2022-08-30T00:00:00\",\"ordersDone\":82,\"shopsDone\":2},{\"id\":31,\"workerId\":3,\"workTime\":7,\"date\":\"2022-08-31T00:00:00\",\"ordersDone\":178,\"shopsDone\":1}]";

        //Properties 
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public string Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }

        public List<WorkDayModel> WorkDays
        {
            get => _workDays;
            set
            {
                _workDays = value;
                OnPropertyChanged(nameof(WorkDays));
            }
        }

        public List<WorkDayDisplayModel> Display
        {
            get => _display;
            set
            {
                _display = value;
                OnPropertyChanged(nameof(Display));
            }
        }


        public HomeViewModel()
        {
            _title = "test";
            _value = "1234 hours";
            _userService = new UserService();
            _workService = new WorkService(_userService.GetActualUser());
            //_workDays = _workService.GetWorkList(_userService.GetActualUser().id);
            DevTests();
        }

        public void DevTests()
        {
            _workDays = JsonSerializer.Deserialize<List<WorkDayModel>>(dev);
            var display = new List<WorkDayDisplayModel>();
            foreach (WorkDayModel day in _workDays)
            {
                display.Add(new WorkDayDisplayModel
                {
                    date = day.date.ToString("dd/MM/yyyy"),
                    ordersDone = day.ordersDone,
                    shopsDone = day.shopsDone,
                    workTime = day.workTime
                });
            }

            Console.Read();
            Display = display;
        }

    }
}
