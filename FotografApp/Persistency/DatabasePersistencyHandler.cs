using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using FotografApp.Model;
using Newtonsoft.Json;

namespace FotografApp.Persistency
{
    class DatabasePersistencyHandler
    {
        #region Singelton
        private readonly static DatabasePersistencyHandler instance = new DatabasePersistencyHandler();

        public static DatabasePersistencyHandler Instance { get { return instance; } }

        private DatabasePersistencyHandler()
        {
            SetupConnection();
        } 
        #endregion

        private HttpClient _client;
        private string _message;
        private const string serverUrl = "http://localhost:55001/api/";

        private void SetupConnection()
        {
            var handler = new HttpClientHandler {UseDefaultCredentials = true};
            _client = new HttpClient();
            _client.BaseAddress = new Uri(serverUrl);
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            try
            {
                var response = _client.GetAsync("Users").Result;
                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    users = JsonConvert.DeserializeObject<List<User>>(json);
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            return users;
        }

        public void AddUser(User user)
        {
            try
            {
                string json = JsonConvert.SerializeObject(user);
                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var response = _client.PostAsync("Users", content).Result;
                Message = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        public void RemoveUser(User user)
        {
            try
            {
                var respone = _client.DeleteAsync("User/" + user.Email).Result;
                Message = _message + " " + respone.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        public void EditUser(User user)
        {
            try
            {
                string json = JsonConvert.SerializeObject(user);
                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var response = _client.PutAsync("User/" + user.Email, content).Result;
                Message = _message + " " + response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }
}
