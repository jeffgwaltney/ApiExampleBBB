using ApplicationApi.Models;

namespace ApplicationApi.Data
{
    public interface IApplicationRepository
    {      
        List<Application> Applications();

        Application Application(int id);

        List<Application> Applications(string category, DateTime date);        
    }
}