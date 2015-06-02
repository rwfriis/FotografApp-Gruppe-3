using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using FotografApp.Model;
using FotografApp.ViewModel;
using Newtonsoft.Json;

namespace FotografApp.Persistency
{
    public class DatabasePersistencyHandler
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

        #region GetData

        public User GetUser(string email, string password)
        {
            try
            {
                var response = _client.GetAsync("Users").Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    var users = JsonConvert.DeserializeObject<List<User>>(json);
                    foreach (var user in users.Where(user => user.Password == password && user.Email == email))
                    {
                        return user;
                    }
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            return null;
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

        public List<Orders> GetOrders()
        {
            List<Orders> orders = new List<Orders>();
            try
            {
                var response = _client.GetAsync("Orders").Result;
                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    orders = JsonConvert.DeserializeObject<List<Orders>>(json);
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            return orders;
        }

        public ObservableCollection<Orders> GetOrdersFromUser(User user)
        {
            var orders = new ObservableCollection<Orders>();
            if (user != null)
            {
                var temp = new ObservableCollection<Orders>();
                try
                {
                    var response = _client.GetAsync("Orders").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string json = response.Content.ReadAsStringAsync().Result;
                        temp = JsonConvert.DeserializeObject<ObservableCollection<Orders>>(json);
                        foreach (var order in temp)
                        {
                            if (order.UserId == user.Id)
                            {
                                orders.Add(order);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                }
            }
            return orders;
        }

        #endregion

        #region AddData
        public Boolean AddUser(User user)
        {
            try
            {
                string json = JsonConvert.SerializeObject(user);
                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var response = _client.PostAsync("Users", content).Result;
                Message = response.Content.ReadAsStringAsync().Result;
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return false;
            }
        }

        public Boolean AddOrder(Orders order)
        {
            try
            {
                string json = JsonConvert.SerializeObject(order);
                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var response = _client.PostAsync("Orders", content).Result;
                Message = response.Content.ReadAsStringAsync().Result;
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return false;
            }
        }
        #endregion

        #region RemoveData
        public bool RemoveUser(int id)
        {
            try
            {
                var response = _client.DeleteAsync("Users/" + id).Result;
                Message = _message + " " + response.IsSuccessStatusCode;
                if (response.IsSuccessStatusCode)
                { return true; }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return false;
            }
            return false;
        }

        public Boolean RemoveOrder(int id)
        {
            try
            {
                var response = _client.DeleteAsync("Orders/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            return false;
        }
        #endregion

        #region EditData
        public void EditUser(User user)
        {
            try
            {
                string json = JsonConvert.SerializeObject(user);
                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var response = _client.PutAsync("Users/" + user.Email, content).Result;
                Message = _message + " " + response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        public void EditOrder(Orders order)
        {
            try
            {
                string json = JsonConvert.SerializeObject(order);
                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var response = _client.PutAsync("Orders/" + order, content).Result;
                Message = _message + " " + response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }
}
