using System.ComponentModel;
using UserManager.ViewModels;
using Xamarin.Forms;

namespace UserManager.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}