using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdiAvalon.ViewModels.ADBase
{
    public class LayoutDocumentViewModel : LayoutContentViewModel
    {
        public LayoutDocumentViewModel(string title = "Document") : base(title)
        {
            // default icon source
            IconSource = "/Assets/Images/document.png";
        }
    }
}
