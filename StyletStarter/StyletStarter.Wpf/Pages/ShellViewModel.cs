using Stylet;
using StyletStarter.Core.ViewModels;

namespace StyletStarter.Wpf.Pages
{
    public class ShellViewModel : Conductor<Screen>
    {
        // `vm` will be injected by stylet IoC
        public ShellViewModel(GuestBookViewModel vm)
        {
            ActiveItem = vm;
        }
    }
}
