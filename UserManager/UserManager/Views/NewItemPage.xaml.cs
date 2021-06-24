using System;
using System.Collections.Generic;
using System.ComponentModel;
using UserManager.Models;
using UserManager.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserManager.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}