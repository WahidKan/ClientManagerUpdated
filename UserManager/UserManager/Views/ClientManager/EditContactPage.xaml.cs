using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserManager.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserManager.Views.ClientManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditContactPage : ContentPage
    {
        public Contact contact;
        
        public EditContactPage()
        {
            InitializeComponent();
        }

        public EditContactPage(Contact selectedContact)
        {
            InitializeComponent();
            contact = selectedContact;
            clientId.Text = selectedContact.Client_ID.ToString();
            firstName.Text = selectedContact.FirstName;
            lastName.Text = selectedContact.LastName;
            email.Text = selectedContact.Email;
            designation.Text = selectedContact.Designation;
            contact_number.Text = selectedContact.Contact_Number.ToString();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            contact.Client_ID = Convert.ToInt32(clientId.Text);
            contact.FirstName = firstName.Text;
            contact.LastName = lastName.Text;
            contact.Email = email.Text;
            contact.Designation = designation.Text;
            contact.Contact_Number = Convert.ToInt32(contact_number.Text);



            Uri uri = new Uri(String.Format(Constants.UpdateContactURL, String.Empty));
            using (HttpClient client = new HttpClient())
            {

                var json = JsonConvert.SerializeObject(contact);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(uri, stringContent);
                //var industries = JsonConvert.DeserializeObject<List<Industry>>(response);
            }

            //IndustryViewModel.addItem(industry);
            await Navigation.PopAsync();
        }
    }
}