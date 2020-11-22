using Stylet;
using DemoLibrary.Models;
using DemoLibrary;

namespace WPFDemoUI.Pages
{

    public class ShellViewModel : Screen
    {
        public BindableCollection<PersonModel> People { get; set; }

        public ShellViewModel()
        {
            var da = new DataAccesss();
            People = new BindableCollection<PersonModel>(da.GetPeople(20));
        }

        private PersonModel personModel;

        public PersonModel SelectedPerson
        {
            get { return personModel; }
            set { SetAndNotify(ref personModel, value); }
        }

    }
}
