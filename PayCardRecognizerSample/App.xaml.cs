using System;
using PayCardRecognizerSample.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PayCardRecognizerSample
{
    public partial class App : Application
    {
        public App(IPayCardRecognizerService payCardRecognizerService)
        {
            InitializeComponent();

            MainPage = new MainPage(payCardRecognizerService);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
