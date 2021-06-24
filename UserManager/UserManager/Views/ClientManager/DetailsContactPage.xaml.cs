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
    public partial class DetailsContactPage : ContentPage
    {
        public DetailsContactPage()
        {
            InitializeComponent();
        }

        public DetailsContactPage(Contact selectedContact)
        {
            InitializeComponent();

            clientId.Text = selectedContact.Client_ID.ToString();
            firstName.Text = selectedContact.FirstName;
            lastName.Text = selectedContact.LastName;
            email.Text = selectedContact.Email;
            designation.Text = selectedContact.Designation;
            contact_number.Text = selectedContact.Contact_Number.ToString();
        }
    }
}