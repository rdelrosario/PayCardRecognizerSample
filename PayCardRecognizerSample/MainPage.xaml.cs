using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayCardRecognizerSample.Services;
using PayCardRecognizerSample.ViewModels;
using Xamarin.Forms;

namespace PayCardRecognizerSample
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage(IPayCardRecognizerService payCardRecognizerService)
        {
            BindingContext = new MainViewModel(payCardRecognizerService);
            InitializeComponent();
        }
    }
}
