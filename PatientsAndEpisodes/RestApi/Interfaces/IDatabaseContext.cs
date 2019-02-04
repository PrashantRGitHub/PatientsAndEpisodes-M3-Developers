using System.Data.Entity;
using System.Linq;
using RestApi.Models;

namespace RestApi.Interfaces
{
 
    public interface IDatabaseContext
    {
        IDbSet<Patient> Patients { get; }

        IDbSet<Episode> Episodes { get; }        

    }
}