using Microsoft.VisualBasic;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using TimeKeeper.Models;

namespace TimeKeeper.Http
{
    public interface IUserService
    {
        User GetActualUser();
        bool AuthenticateUser(NetworkCredential networkCredential);
        User DisplayUserInfo(string token);
        string GetLoginToken(UserLoginModel userLoginModel);
        bool LoginUser(UserLoginModel userLoginModel);
    }

    public class UserService : IUserService
    {
        private User _user;
        private readonly ApiConstants _constants;

        public UserService()
        {
            _user = new User();
            _constants = new ApiConstants();
        }
        public UserService(User user)
        {
            _user = user;
            _constants = new ApiConstants();
        }
        public UserService(string token)
        {
            _user = new User();
            _user.token = token;
            _constants = new ApiConstants();
        }



        public User GetActualUser() => _user.name != null ? _user : DisplayUserInfo(_user.token);

        public bool AuthenticateUser(NetworkCredential networkCredential)
        {
            var logged = LoginUser(new UserLoginModel(networkCredential.UserName, networkCredential.Password));
            return logged;
        }

        public bool LoginUser(UserLoginModel userLoginModel)
        {
            _user.token = GetLoginToken(userLoginModel);
            if (_user.token == null)
                return false;
            return true;
        }

        public string GetLoginToken(UserLoginModel userLoginModel)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri(_constants.GetAccountLogin());

                var newPostJson = JsonSerializer.Serialize(userLoginModel);
                var payload = new StringContent(newPostJson, Encoding.UTF8, "application/json");

                var result = client.PostAsync(uri, payload).Result.Content.ReadAsStringAsync().Result;
                if (result is "Something went wrong" or "Invalid username or password") return null;
                return result;
            }
        }

        public void GetUser(string token)
        {
            if (string.IsNullOrEmpty(token)) return;

            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri(_constants.GetLogged());

                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                
                var newPostJson = JsonSerializer.Serialize(token);
                var payload = new StringContent(newPostJson, Encoding.UTF8, "application/json");

                var result = client.PostAsync(uri, payload).Result.Content.ReadAsStringAsync().Result;
                var jsonObject = JsonSerializer.Deserialize<JsonObject>(result) ?? throw new Exception("Wrong result!");
                _user.id = Int32.Parse(jsonObject["value"]!.ToString());
            }

            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri(_constants.GetUserById(_user.id));

                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                var result = client.GetAsync(uri).Result.Content.ReadAsStringAsync().Result;

                var json = JsonSerializer.Deserialize<JsonObject>(result) ?? throw new Exception("Wrong result!");

                _user.name = json["email"]!.ToString();
                _user.name = json["name"]!.ToString();
                _user.surname = json["surname"]!.ToString();
                _user.roleId = Int32.Parse(json["roleId"]!.ToString());
            }
        }

        public User DisplayUserInfo(string token)
        {
            GetUser(token);
            return _user;
        }
    }
}
