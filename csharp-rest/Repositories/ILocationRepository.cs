using bos.Models;
using System.Collections.Generic;

namespace bos.Repositories
{
    public interface ILocationRepository
    {
        Location AddLocation(Location Location);
        Location UpdateLocation(Location Location);
        List<Location> GetAll();
        List<Location> SearchByName(string startsWith);
        Location GetById(global::System.Int32 id);
    }
}