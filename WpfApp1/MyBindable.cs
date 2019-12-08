
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;

    using System.Linq;
    using System.Runtime.CompilerServices;

    namespace Pandap.Logic.Model
    {
        public class MyBindableBase : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;



            public bool SetProperty<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
            {
                if (EqualityComparer<T>.Default.Equals(field, value)) return false;

                field = value;
                OnPropertyChanged(propertyName);

                return true;
            }

            public void OnPropertyChanged([CallerMemberName]string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

         

        }
    }
