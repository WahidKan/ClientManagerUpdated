using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Windows.Input;
using UserManager.Models;
using Xamarin.Forms;

namespace UserManager.ViewModels
{
    public class ProjectViewModel : BaseViewModel
    {
        public ICommand EditCommand => new Command(EditIndustry);

        //private SQLiteAsyncConnection _db;

        public static ObservableCollection<Project> _projects = new ObservableCollection<Project>();
        public ObservableCollection<Project> Projects
        {
            get { return _projects; }
            set
            {
                if (_projects == value)
                    return;

                _projects = value;
                OnPropertyChanged();
            }
        }

        public List<Project> list { get; set; }

        public async void GetAllProjects()
        {
            Uri uri = new Uri(String.Format(Constants.GetAllProjectsURL, String.Empty));

            //HttpClientHandler handler = new HttpClientHandler();
            //handler.UseDefaultCredentials = true;

            using (HttpClient client = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await client.GetAsync(uri);
                    //var industries = JsonConvert.DeserializeObject<List<Industry>>(response);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        list = JsonConvert.DeserializeObject<List<Project>>(content);
                    }
                    else
                    {
                        Console.WriteLine("nothing");
                    }
                }
                catch (System.Net.Http.HttpRequestException ex)
                {
                    Debug.WriteLine(@"\tERROR {0}", ex.Message);
                }

                catch (Exception ex)
                {
                    Debug.WriteLine(@"\tERROR {0}", ex.Message);
                }
            }




            //Industries = new List<Industry>();




            //var industryRepository = new IndustryRepository();
            //var list = await industryRepository.GetIndustries();

            ObservableCollection<Project> oc = new ObservableCollection<Project>();

            foreach (var item in list)
            {
                oc.Add(item);
            }

            Console.WriteLine(oc);

            //_industriesList = oc;
            Projects = oc;



        }



        public ProjectViewModel()
        {
            GetAllProjects();
        }


        public void EditIndustry()
        {
            //Industries.Add(new Industry { ID = 5, Industry_Name = "aaa" });
        }

        public static void addItem(Project project)
        {
            if (project != null)
            {
                _projects.Add(project);
            }

        }
    }
}
