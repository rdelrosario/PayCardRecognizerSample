using System;
using System.Threading.Tasks;
using PayCardRecognizerSample.Models;

namespace PayCardRecognizerSample.Services
{
    public interface IPayCardRecognizerService
    {
        Task<PayCard> ScanAsync();
    }
}
