using Stylet;
using StyletStarter.Core.ViewModels;

namespace StyletStarter.Wpf.Pages
{
    public class ShellViewModel : Screen
    {
        public ShellViewModel()
        {
            Content = new GuestBookViewModel();
        }

        public GuestBookViewModel Content { get; private set; }
    }
}
