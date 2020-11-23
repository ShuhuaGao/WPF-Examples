using Stylet;
using DemoLibrary.Models;
using DemoLibrary;
using System.Diagnostics;
using System.Linq;


namespace WPFDemoUI.Pages
{

    public class ShellViewModel : Screen
    {
        public BindableCollection<PersonModel> People { get; set; }

        private DataAccesss da = new DataAccesss();

        public ShellViewModel()
        {
            People = new BindableCollection<PersonModel>(da.GetPeople(20));
        }

        private PersonModel personModel;

        public PersonModel SelectedPerson
        {
            get { return personModel; }
            set
            {
                //SetAndNotify(ref personModel, value);
                personModel = value;
                Debug.WriteLine($"------ Selected: {personModel.FullName}");
                Debug.WriteLine($"Primary address: {personModel.PrimaryAddress.FullAddress}");
                NotifyOfPropertyChange(nameof(SelectedPerson));
            }
        }


        public void AddPerson()
        {
            int maxId = People.Count > 0 ? People.Max(p => p.PersonId) : 0;
            People.Add(da.GetPerson(maxId + 1));
        }


        public void RemovePerson()
        {
            if (People.Count == 0)
                return;
            var rnd = new System.Random();

            var index = rnd.Next(People.Count);
            People.RemoveAt(index); // provides notifications when items get added, removed
        }

    }
}
