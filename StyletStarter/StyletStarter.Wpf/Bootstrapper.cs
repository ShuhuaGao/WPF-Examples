using StyletStarter.Wpf.Pages;
using Stylet;
using StyletIoC;

namespace StyletStarter.Wpf
{
    public class Bootstrapper : Bootstrapper<ShellViewModel>
    {
        protected override void ConfigureIoC(IStyletIoCBuilder builder)
        {
            // Configure the IoC container in here
        }

        protected override void Configure()
        {
            // Perform any other configuration before the application starts
            var viewManager = this.Container.Get<ViewManager>();
            viewManager.NamespaceTransformations.Add("StyletStarter.Core.ViewModels", "StyletStarter.Wpf.Views");
        }
    }
}
