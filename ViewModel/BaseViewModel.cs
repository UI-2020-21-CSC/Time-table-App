
//using CommunityToolkit.Mvvm.ComponentModel;
//using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Time_table.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        bool isBusy;
        string title;
        // Get the Community ToolKit From the Nuget Packet Manager Later
        public bool IsBusy
        {
            get => isBusy;

            set
            {
                if (isBusy == value)
                    return;

                isBusy = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsNotBusy));
            }
        }

        public string Title
        {
            get => title;

            set
            {
                if (title == value) return;

                title = value;
                OnPropertyChanged();
            }
        }
        public bool IsNotBusy => !IsBusy;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
