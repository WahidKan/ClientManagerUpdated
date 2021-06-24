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
using Xamarin.Forms.Xaml;

namespace UserManager.Views.ClientManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientPage : ContentPage
    {
        public ObservableCollection<object> selectedItems;

        public ClientPage()
        {
            InitializeComponent();
        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateClient());
        }

        private void EditButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditClientPage((Client)this.dataGrid.SelectedItem));

        }
        private void DetailsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DetailsClientPage((Client)this.dataGrid.SelectedItem));

        }
        //private void DeleteButton_Clicked(object sender, EventArgs e)
        //{
        //}
    }


}