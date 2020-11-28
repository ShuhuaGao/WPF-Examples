using Stylet;
using CustomTabUI.Models;

namespace CustomTabUI.ViewModels
{
    public class ShellViewModel : Conductor<Student>.Collection.OneActive
    {
        public ShellViewModel()
        {
            Items.Add(new Student { Age = 23, Name = "Jim", Sex = Sex.Male });
            Items.Add(new Student { Age = 24, Name = "Emma", Sex = Sex.Female });
            Items.Add(new Student { Age = 21, Name = "Sophia", Sex = Sex.Female });

            // can also set ActiveItem directly
            ActivateItem(Items[1]);
        }
    }
}
