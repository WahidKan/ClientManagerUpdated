using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UserManager.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace UserManager.Views.ClientManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactPage : ContentPage
    {
        public ContactPage()
        {
            InitializeComponent();
        }

        private void Add_Clicked(object sender, EventArgs e)
        {

            Log.Warning("Infoo", "Entered Add Method");
            Navigation.PushAsync(new CreateContact());
        }

        private void EditButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditContactPage((Contact)this.dataGrid.SelectedItem));
        }
        private void DetailsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DetailsContactPage((Contact)this.dataGrid.SelectedItem));
        }

        //private void DeleteButton_Clicked(object sender, EventArgs e)
        //{
        //}
    }
   
}