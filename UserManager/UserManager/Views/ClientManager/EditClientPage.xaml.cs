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
    public partial class EditClientPage : ContentPage
    {
        public Client client;
        public EditClientPage()
        {
            InitializeComponent();
        }

        public EditClientPage(Client selectedClient)
        {
            InitializeComponent();
            client = selectedClient;

            industryId.Text = Convert.ToString(selectedClient.Industry_ID);
            clientName.Text = selectedClient.Client_Name;
            address.Text = selectedClient.Client_Address;
            city.Text = selectedClient.City;
            country.Text = selectedClient.Country;
            contact_number.Text = Convert.ToString(selectedClient.Contact_Number);
            email.Text = selectedClient.Email;

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            client.Industry_ID = Convert.ToInt32(industryId.Text);
            client.Client_Name = clientName.Text;
            client.Client_Address = address.Text;
            client.City = city.Text;
            client.Country = country.Text;
            client.Contact_Number = Convert.ToInt32(contact_number.Text);
            client.Email = email.Text;


            Uri uri = new Uri(String.Format(Constants.UpdateClientURL, String.Empty));
            using (HttpClient httpClient = new HttpClient())
            {

                var json = JsonConvert.SerializeObject(client);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(uri, stringContent);
                //var industries = JsonConvert.DeserializeObject<List<Industry>>(response);
            }

            //IndustryViewModel.addItem(industry);
            await Navigation.PopAsync();




        }
    }
}