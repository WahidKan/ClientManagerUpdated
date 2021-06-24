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
    class ContactViewModel : BaseViewModel
    {


        public ICommand EditCommand => new Command(EditIndustry);

        //private SQLiteAsyncConnection _db;

        public static ObservableCollection<Contact> _contacts = new ObservableCollection<Contact>();
        public ObservableCollection<Contact> Contacts
        {
            get { return _contacts; }
            set
            {
                if (_contacts == value)
                    return;

                _contacts = value;
                OnPropertyChanged();
            }
        }


        public ContactViewModel()
        {

            GetAllContacts();
        }


        public void EditIndustry()
        {
            //Industries.Add(new Industry { ID = 5, Industry_Name = "aaa" });
        }

        public static void addItem(Contact contact)
        {
            if (_contacts != null)
            {
                _contacts.Add(contact);
            }

        }

        public List<Contact> list { get; set; }

        public async void GetAllContacts()
        {
            //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //{

            //    List<Contact> list = conn.Table<Contact>().ToList();
            //    ObservableCollection<Contact> oc = new ObservableCollection<Contact>();

            //    foreach (var item in list)
            //    {
            //        oc.Add(item);
            //    }

            //    Console.WriteLine(oc);

            //    return oc;

            //}

            Uri uri = new Uri(String.Format(Constants.GetAllContactsURL, String.Empty));

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
                        list = JsonConvert.DeserializeObject<List<Contact>>(content);
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

            ObservableCollection<Contact> oc = new ObservableCollection<Contact>();

            foreach (var item in list)
            {
                oc.Add(item);
            }

            Console.WriteLine(oc);

            //_industriesList = oc;
            Contacts = oc;



        }



    }
}
