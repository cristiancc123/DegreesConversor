namespace DegreesConversor.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    public class MainViewModels : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        #region Attributes

        string _result;
        string _celsius;
        string _fahrenheit;

        #endregion

        #region Properties

        public string Fahrenheit
        {
            get { return _fahrenheit; }
            set
            {
                if (value != _fahrenheit)
                {
                    _fahrenheit = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Fahrenheit)));
                }
            }
        }

        public string Celsius
        {
            get { return _celsius; }
            set
            {
                if (value != _celsius)
                {
                    _celsius = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Celsius)));
                }
            }
        }

        public string Result
        {
            get { return _result; }
            set
            {
                if (value != _result)
                {
                    _result = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Result)));
                }
            }
        }

        #endregion

        #region Commands

        public ICommand ConvertToCelsius
        {
            get { return new RelayCommand(ConvertCelsius); }
        }

        public ICommand ConvertToFahrenheit
        {
            get { return new RelayCommand(ConvertFahrenheit); }
        }

        

        #endregion

        #region Metods

        async void ConvertCelsius()
        {
            if (string.IsNullOrEmpty(Fahrenheit))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You must enter the value in Degress Fahrenheit", "Accept");
            }

            else
            {
                Celsius = null;

                double fahrenheit;
                double.TryParse(Fahrenheit, out fahrenheit);

                var result = (fahrenheit - 32) / 1.8;

                Result = string.Format("{0} Degrees Celsius", result);
            }
        }

        async void ConvertFahrenheit()
        {
            if (string.IsNullOrEmpty(Celsius))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You must enter the value in Degress Celsius", "Accept");
            }

            else
            {
                Fahrenheit = null;

                double celsius;
                double.TryParse(Celsius, out celsius);

                var result = (celsius * 1.8) + 32;

                Result = string.Format("{0} Degrees Fahrenheit", result);
            }
        }

        #endregion

    }
}
