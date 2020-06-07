using System;
namespace PayCardRecognizerSample.Models
{
    public class PayCard
    {
        public string HolderName { get; set; }

        public string CardNumber { get; set; }

        public string ExpirationDate { get; set; }
    }
}
