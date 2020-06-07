using System;
using PayCardRecognizerSample.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace PayCardRecognizerSample.ViewModels
{
    public class MainViewModel
    {
        IPayCardRecognizerService _payCardRecognizerService;

        public ICommand ScanCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        var card = await _payCardRecognizerService.ScanAsync();
                        await App.Current.MainPage.DisplayAlert("Result", $"{card.HolderName}\n{card.CardNumber}\n{card.ExpirationDate}","Ok");
                    }
                    catch(Exception ex)
                    {

                    }
                   
                });
            }
        }

        public MainViewModel(IPayCardRecognizerService payCardRecognizerService)
        {
            _payCardRecognizerService = payCardRecognizerService;
        }

    }
}
