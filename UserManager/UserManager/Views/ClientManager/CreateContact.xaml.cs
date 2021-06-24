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
    public partial class CreateContact : ContentPage
    {
        public CreateContact()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Contact contact = new Contact();
            contact.Client_ID = Convert.ToInt32(clientId.Text);
            contact.FirstName = firstName.Text;
            contact.LastName = lastName.Text;
            contact.Email = email.Text;
            contact.Designation = designation.Text;
            contact.Contact_Number = Convert.ToInt32(contact_number.Text);

            //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //{
            //    conn.CreateTable<Contact>();
            //    conn.Insert(contact);
            //    ContactViewModel.addItem(contact);
            //    Navigation.PopAsync();
            //}
            Uri uri = new Uri(String.Format(Constants.AddContactURL, String.Empty));

            using (HttpClient httpclient = new HttpClient())
            {

                var json = JsonConvert.SerializeObject(contact);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpclient.PostAsync(uri, stringContent);
            }

            ContactViewModel.addItem(contact);
            await Navigation.PopAsync();
        }




    }
}