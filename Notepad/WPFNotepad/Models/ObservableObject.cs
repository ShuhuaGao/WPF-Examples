using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WPFNotepad.Models
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            bool changed = !EqualityComparer<T>.Default.Equals(field, value);
            if (changed)
            {
                field = value;
                // https://stackoverflow.com/questions/872323/method-call-if-not-null-in-c-sharp/22157328
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

        }
    }
}
