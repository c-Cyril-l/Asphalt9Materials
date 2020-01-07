using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Helpers.Utilities
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies the change of the property.
        /// </summary>
        /// <param name="propertyName">The Property that has been changed...</param>
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}