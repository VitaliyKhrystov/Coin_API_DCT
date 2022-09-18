using System;
using System.ComponentModel;


namespace Coin_API__DCT.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        public ViewModelBase()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void Dispose()
        {
            this.OnDispose();
        }

        protected virtual void OnDispose()
        {
        }

    }
}
