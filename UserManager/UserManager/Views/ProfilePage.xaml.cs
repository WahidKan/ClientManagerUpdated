using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        User user = new User();
        public ProfilePage()
        {
            InitializeComponent();
            var assembly = typeof(ProfilePage);
            resultImage.Source = ImageSource.FromResource("UserManager.Assets.Images.profile.png", assembly);
        }

        public ProfilePage(string x)
        {
            InitializeComponent();
            var assembly = typeof(ProfilePage);
            resultImage.Source = ImageSource.FromResource("UserManager.Assets.Images.profile.png", assembly);

            userNameLabel.Text = x;
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Please pick a photo"
            });

            if (result != null)
            {
                var stream = await result.OpenReadAsync();

                resultImage.Source = ImageSource.FromStream(() => stream);
                //Profile profile = new Profile(stream);
                //_ = Navigation.PushAsync(new Profile(stream));
               // Navigation.PushAsync(new Camera());

            }
        }

        async void Button1_Clicked(System.Object sender, System.EventArgs e)
        {
            var result = await MediaPicker.CapturePhotoAsync();

            if (result != null)
            {
                var stream = await result.OpenReadAsync();

                resultImage.Source = ImageSource.FromStream(() => stream);
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

            //Item item = new Item();
            // UpdateProfile updateProfile = new UpdateProfile();
            // updateProfile.BindingContext= item;
            Navigation.PushAsync(new UpdateProfile(user));

        }
        protected override void OnAppearing()
        {
           
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<User>();
                var users = conn.Table<User>().ToList();
                //userListView.ItemsSource = users;
                Console.Write("Users:" + users);
                if(users != null && (users.Count != 0) )
                {
                    user = users.FirstOrDefault(x => x.UserName == "test");
                    if (user != null)
                    {
                        userNameLabel.Text = user.UserName;
                        firstNameLabel.Text = user.FirstName;
                        lastNameLabel.Text = user.LastName;
                        emailLabel.Text = user.Email;
                        
                    }
                    else
                        DisplayAlert("Failure", "No Ali record Found!", "OK");
                }
                else
                    DisplayAlert("Failure", "No record Found!", "OK");
            }

            base.OnAppearing();

        }
    }
}