using Stylet;
using StyletStarter.Core.Models;

namespace StyletStarter.Core.ViewModels
{
    public class GuestBookViewModel : Screen
    {
        // a collection of models
        private BindableCollection<PersonModel> people = new BindableCollection<PersonModel>();

        public BindableCollection<PersonModel> People
        {
            get { return people; }
            set { SetAndNotify(ref people, value); }
        }



        // expose the properties of a model that can notify changes
        // if either firstName or lastName is changed, then the FullName is also changed.
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                // both methods below are inherinted from `PropertyChangedBase`
                SetAndNotify(ref firstName, value);
                NotifyOfPropertyChange(nameof(FullName));
                NotifyOfPropertyChange(nameof(CanAddGuest));
            }
        }


        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set
            {
                SetAndNotify(ref lastName, value);
                NotifyOfPropertyChange(nameof(FullName));
                NotifyOfPropertyChange(nameof(CanAddGuest));
            }
        }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }


        // "Command" to be called by clicking the button
        public void AddGuest()
        {
            var p = new PersonModel { FirstName = this.FirstName, LastName = this.LastName };
            People.Add(p);
            // clear the two textboxes
            FirstName = string.Empty;
            LastName = string.Empty;
        }

        // Guard property for the `AddGuest` action: just a getter-only property (like `FullName`)
        // We use the "expression body" syntax introduced in C# 6.
        // The returned value controls whether the button is enabled. 
        public bool CanAddGuest => FirstName?.Length > 0 && LastName?.Length > 0;
    }
}
