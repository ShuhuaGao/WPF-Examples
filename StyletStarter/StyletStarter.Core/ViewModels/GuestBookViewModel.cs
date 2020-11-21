using Stylet;
using StyletStarter.Core.Models;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;

namespace StyletStarter.Core.ViewModels
{
    public class GuestBookViewModel : Screen
    {
        private IWindowManager windowManager;

        // constructor injection
        public GuestBookViewModel(IWindowManager windowManager)
        {
            this.windowManager = windowManager;
        }

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
                // both methods below are inherited from `PropertyChangedBase`
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

        // Called when the Screen's activated. Will only be called if the Screen wasn't already active.
        protected override void OnActivate()
        {
            base.OnActivate();
            Debug.WriteLine("------ OnActivate in GuestBookViewModel");
        }

        // Called when the Screen's closed. Will only be called once. 
        protected override void OnClose()
        {
            base.OnClose();
            Debug.WriteLine("------ OnClose in GuestBookViewModel");
        }


        public override Task<bool> CanCloseAsync()
        {
            var result = windowManager.ShowMessageBox(
                "Save the guest book to file?", // main text
                "My App", // caption
                MessageBoxButton.YesNoCancel
                );

            if (result == MessageBoxResult.Yes)
                Debug.WriteLine("----- Saved the guest book to file");
            else if (result == MessageBoxResult.No)
                Debug.WriteLine("----- Discarded the guest book");

            return Task.FromResult<bool>(result != MessageBoxResult.Cancel);
        }

    }
}
