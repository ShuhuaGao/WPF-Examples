using Zhaoxi.CourseManagement.ViewModels;
using Stylet;
using StyletIoC;

namespace Zhaoxi.CourseManagement
{
    public class Bootstrapper : Bootstrapper<LoginViewModel>  // entry point
    {
        protected override void ConfigureIoC(IStyletIoCBuilder builder)
        {
            // Configure the IoC container in here
        }

        protected override void Configure()
        {
            // Perform any other configuration before the application starts
        }
    }
}
