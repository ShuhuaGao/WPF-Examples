using Stylet;
using StyletStarter.Core.ViewModels;

namespace StyletStarter.Wpf.Pages
{
    public class ShellViewModel : Conductor<Screen>
    {
        public ShellViewModel()
        {
            ActiveItem = new GuestBookViewModel();
        }
    }
}
