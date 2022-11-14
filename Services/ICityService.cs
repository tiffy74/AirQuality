using AirQuality.Models;
using System.Threading.Tasks;

namespace AirQuality.Services
{
    public interface ICityService
    {
        Task<Root> GetAllCities(string city);
        Task<Root> GetAllCountries(string country);
    }
}
