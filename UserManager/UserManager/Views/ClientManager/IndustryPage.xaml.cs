
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
using TodoREST;
using UserManager.Models;
using UserManager.Services;
using UserManager.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserManager.Views.ClientManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IndustryPage : ContentPage
    {
        public ObservableCollection<object> selectedItems;

        public IndustryPage()
        {
            InitializeComponent();

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            DataGrid.ItemsSource = await App.TodoManager.GetTasksAsync();
            //protected override void OnAppearing()
            //{
            //    //GetAllIndustries();
            //    DataGrid.ItemsSource = App.TodoManager.GetTasksAsync();
            //    Console.WriteLine("inside on apperaing");
            //    base.OnAppearing();
            //    //IndustryViewModel.GetAllIndustries();
            //    //InitializeComponent();


            //    //var industryVM = new IndustryVM();
            //    //industryVM.GetAllIndustries();
            //}

        }



            private void ToolbarItem_Clicked(object sender, EventArgs e)
        {

        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            //logService.LogInfo("This is not an exception for...");
            System.Diagnostics.Debug.Print("Blablablalbala");
            Navigation.PushAsync(new CreateIndustry());

        }
        private bool CanExecuteGoToEditItemCommand(object arg)
        {
            bool canExecute = this.selectedItems != null && this.selectedItems.Count == 1;
            return canExecute;
        }
        private void GoToEditItem(object arg)
        {
            //Industry industry = new Industry((Industry)this.selectedItems[0]);
            //this.NavigationService.NavigateToConfigurationAsync(editItemViewModel);
        }

        private void DetailsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DetailsIndustryPage((Industry)this.DataGrid.SelectedItem));
        }

        private void EditButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditIndustryPage((Industry)this.DataGrid.SelectedItem));
        }

        private void RefreshButton_Clicked(object sender, EventArgs e)
        {
            var vUpdatedPage = new IndustryPage(); Navigation.InsertPageBefore(vUpdatedPage, this); Navigation.PopAsync();
            //Navigation.RemovePage();

        }

        //private void DeleteButton_Clicked(object sender, EventArgs e)
        //{

        //}


    }




}