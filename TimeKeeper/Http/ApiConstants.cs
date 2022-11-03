using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeKeeper.Http
{
    public class ApiConstants
    {
        //App API
        private string API_BASE;
        private string ACCOUNT_LOGIN;
        private string ACCOUNT_REGISTER;
        private string USER_BY_ID; // add id at the end
        private string TEST;
        private string TEST_USERS;
        private string LOGGED;
        private string WORK_TIME_ADD;
        private string WORK_TIME_GET;
        private string WORK_TIME_EDIT;
        private string WORK_TIME_DELETE;
        //Weather API
        private string CONNECION;
        private string API_KEY;


        public ApiConstants()
        {
            //App API
            API_BASE = "https://rescheduller-api.azurewebsites.net/api";
            ACCOUNT_LOGIN = API_BASE + "/account/login";
            ACCOUNT_REGISTER = API_BASE + "/account/register";
            USER_BY_ID = API_BASE + "/users/"; // add id at the end
            TEST = API_BASE + "/test";
            TEST_USERS = API_BASE + "/test/users";
            LOGGED = API_BASE + "/users/logged";
            WORK_TIME_ADD = API_BASE + "/work/add";
            WORK_TIME_GET = API_BASE + "/work/"; // add id at the end
            WORK_TIME_EDIT = API_BASE + "/work";
            WORK_TIME_DELETE = API_BASE + "/work/"; // add id at the end
            //Weather API
            CONNECION = "http://api.weatherbit.io/v2.0/current?";
            API_KEY = "f11b0de69c8948b0965a9c0970da0647";
        }

        public string GetApiBase() => API_BASE;
        public string GetAccountLogin() => ACCOUNT_LOGIN;
        public string GetAccountRegister() => ACCOUNT_REGISTER;
        public string GetUserById(int id) => USER_BY_ID + id;
        public string GetTest() => TEST;
        public string GetTestUsers() => TEST_USERS;
        public string GetLogged() => LOGGED;
        public string GetWorkTimeAdd() => WORK_TIME_ADD;
        public string GetWorkTimeGet(int id) => WORK_TIME_GET + id;
        public string GetWorkTimeEdit() => WORK_TIME_EDIT;
        public string GetWorkTimeDelete(int id) => WORK_TIME_DELETE + id;
        public string GetApiConnecionString() => CONNECION;

    }
}
