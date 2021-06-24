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
    public partial class ProjectPage : ContentPage
    {
        public ProjectPage()
        {
            InitializeComponent();
        }

        
        private void AddButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateProject());
        }

        private void EditButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditProjectPage((Project)this.dataGrid.SelectedItem));
        }
        private void DetailsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DetailsProjectPage((Project)this.dataGrid.SelectedItem));
        }

        //private void DeleteButton_Clicked(object sender, EventArgs e)
        //{

        //}


    }
    
}