using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Windows.Input;
using UserManager.Models;
using Xamarin.Forms;

namespace UserManager.ViewModels
{
    class ClientViewModel : BaseViewModel
    {

        public ICommand EditCommand => new Command(EditIndustry);

        //private SQLiteAsyncConnection _db;

        public static ObservableCollection<Client> _clients = new ObservableCollection<Client>();
        public ObservableCollection<Client> Clients
        {
            get { return _clients; }
            set
            {
                if (_clients == value)
                    return;

                _clients = value;
                OnPropertyChanged();
            }
        }


        public List<Client> list { get; set; }
        public async void GetAllClients()
        {
            //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //{

            //    List<Client> list = conn.Table<Client>().ToList();
            //    ObservableCollection<Client> oc = new ObservableCollection<Client>();

            //    foreach (var item in list)
            //    {
            //        oc.Add(item);
            //    }

            //    Console.WriteLine(oc);

            //    return oc;

            //}



            Uri uri = new Uri(String.Format(Constants.GetAllClientsURL, String.Empty));

            //HttpClientHandler handler = new HttpClientHandler();
            //handler.UseDefaultCredentials = true;

            using (HttpClient client = new HttpClient())
            {
                try
                {


                    HttpResponseMessage response = await client.GetAsync(uri);
                    //var industries = JsonConvert.DeserializeObject<List<Industry>>(response);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        list = JsonConvert.DeserializeObject<List<Client>>(content);
                    }
                    else
                    {
                        Console.WriteLine("nothing");
                    }
                }
                catch (System.Net.Http.HttpRequestException ex)
                {
                    Debug.WriteLine(@"\tERROR {0}", ex.Message);
                }

                catch (Exception ex)
                {
                    Debug.WriteLine(@"\tERROR {0}", ex.Message);
                }
            }




            //Industries = new List<Industry>();




            //var industryRepository = new IndustryRepository();
            //var list = await industryRepository.GetIndustries();

            ObservableCollection<Client> oc = new ObservableCollection<Client>();

            foreach (var item in list)
            {
                oc.Add(item);
            }

            Console.WriteLine(oc);

            //_industriesList = oc;
            Clients = oc;


        }



        public ClientViewModel()
        {
            GetAllClients();

            //try
            //{
            //    using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //    {
            //        conn.CreateTable<Client>();
            //        for (int i = 0; i < _clients.Count; i++)
            //        {
            //            conn.Insert(_clients[i]);
            //        }

            //        _clients = GetAllClients();

            //    }
            //}

            //catch (TargetInvocationException e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
        }



        public void EditIndustry()
        {
            //Clients.Add(new Client { ID = 5, I = "aaa" });
        }

        public static void addItem(Client client)
        {
            if (client != null)
            {
                _clients.Add(client);
            }

        }
        public static void editItem(Client client)
        {
            if (client != null)
            {

                ObservableCollection<Client> _tempList = _clients;

                foreach (Client client1 in _clients)
                {
                    if (client.ID.Equals(client1.ID))
                    {
                        _tempList.Remove(client1);
                        _tempList.Add(client);
                        //int index = _industriesList.IndexOf(industry1);
                        //_tempList.Add(industry);
                        //_tempList.Replace
                        break;
                    }
                }

                _clients = _tempList;

            }
        }

    }
}
