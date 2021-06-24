using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserManager.Views.ClientManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsClientPage : ContentPage
    {
        public DetailsClientPage()
        {
            InitializeComponent();
        }

        public DetailsClientPage(Client selectedClient)
        {
            InitializeComponent();

            industryId.Text = Convert.ToString(selectedClient.Industry_ID);
            clientName.Text = selectedClient.Client_Name;
            address.Text = selectedClient.Client_Address;
            city.Text = selectedClient.City;
            country.Text = selectedClient.Country;
            contact_number.Text = Convert.ToString(selectedClient.Contact_Number);
            email.Text = selectedClient.Email;
        }
    }
}