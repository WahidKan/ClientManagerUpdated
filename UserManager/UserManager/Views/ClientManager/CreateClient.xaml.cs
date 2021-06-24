using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserManager.Models;
using UserManager.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserManager.Views.ClientManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateClient : ContentPage
    {
        public CreateClient()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Client client = new Client();
            client.Industry_ID = Convert.ToInt32(industryId.Text);
            client.Client_Name = clientName.Text;
            client.Client_Address = address.Text;
            client.City = city.Text;
            client.Country = country.Text;
            client.Contact_Number = Convert.ToInt32(contact_number.Text);
            client.Email = email.Text;

            //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //{
            //    conn.CreateTable<Client>();
            //    conn.Insert(client);
            //    ClientViewModel.addItem(client);
            //    Navigation.PopAsync();
            //}
            Uri uri = new Uri(String.Format(Constants.AddClientURL, String.Empty));

            using (HttpClient httpclient = new HttpClient())
            {

                var json = JsonConvert.SerializeObject(client);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpclient.PostAsync(uri, stringContent);
                //var industries = JsonConvert.DeserializeObject<List<Industry>>(response);
            }

            ClientViewModel.addItem(client);
            await Navigation.PopAsync();
        }
    }
}