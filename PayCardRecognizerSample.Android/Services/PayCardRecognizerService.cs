using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Runtime;
using Cards.Pay.Paycardsrecognizer.Sdk;
using PayCardRecognizerSample.Models;
using PayCardRecognizerSample.Services;

namespace PayCardRecognizerSample.Droid.Services
{
    public class PayCardRecognizerService : IPayCardRecognizerService
    {
        static TaskCompletionSource<PayCard> _cardTcs;
        static int _requestCodeScanCard = 1734;
        Activity _activity;

        public static void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if(requestCode == _requestCodeScanCard)
            {
                if(resultCode == Result.Ok)
                {
                    Card card = data.GetParcelableExtra(ScanCardIntent.ResultPaycardsCard).JavaCast<Card>();

                    _cardTcs.TrySetResult(new PayCard()
                    {
                        HolderName = card.CardHolderName,
                        CardNumber = card.CardNumber,
                        ExpirationDate = card.ExpirationDate
                    });
                }
                else
                {
                    _cardTcs.TrySetCanceled();
                }
            }
        }

        public PayCardRecognizerService(Activity activity,int requestCode = 1734)
        {
            _requestCodeScanCard = requestCode;
            _activity = activity;


        }

        public async Task<PayCard> ScanAsync()
        {
            _cardTcs = new TaskCompletionSource<PayCard>();
            Intent intent = new ScanCardIntent.Builder(_activity).Build();
            _activity.StartActivityForResult(intent, _requestCodeScanCard);
            return await _cardTcs.Task;
        }
    }
}
