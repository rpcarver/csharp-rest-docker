using bos.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

/// <summary>
/// Implementation of Location repository 
/// NOTE: this is stripped down, it should really have a delete, counts and paging information
/// </summary>
namespace bos.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        // rcarver - no db/persistence atm
        private static ConcurrentDictionary<int, Location> _store = new ConcurrentDictionary<int, Location>();
        private static int _highId = 1;

        public LocationRepository()
        {
            Location Location = new Location();
            Location.LocationId = 1;
            Location.Name = "Test Location";
            HashSet<UseType> UseTypes = new HashSet<UseType>();
            UseType i = new UseType(1, "Hiking", "All about da feet");
            Location.AddUse(i);
            i = new UseType(3, "Horse Riding", "Fred'll carry it");
            Location.AddUse(i);
            _store.TryAdd(1, Location);
        }

        public List<Location> GetAll() => _store.Values.ToList();

        /// <summary>
        /// Returns all Locations that start with the startsWith
        /// </summary>
        /// <param name="startsWith"></param>
        /// <returns></returns>
        public List<Location> SearchByName(string startsWith)
        {
            List<Location> retVal = new List<Location>();
            if (startsWith != null)
            {
                retVal = _store.Values.Where(item => item.Name.StartsWith(startsWith)).ToList();
            }
            return retVal;
        }


        /// <summary>
        /// Returns null if a Location with the specified id is not found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Location GetById(int id)
        {
            if (_store.ContainsKey(id))
            {
                return _store[id];
            }
            return null;
        }
        /// <summary>
        /// Add a Location, returns the Location if added, or null if the Location id already exists or
        /// could not be created
        ///</summary>
        /// <param name=""></param>
        /// <returns></returns>
        public Location AddLocation(Location Location)
        {
            Location retVal = null;
            if (Location != null)
            {
                // high id would probably come from the db insertion
                Location.LocationId = GetNextHighId();
                // paranoia, in case the high id/concurrent dictionary isn't working right
                if (!_store.ContainsKey(Location.LocationId))
                {
                    if (_store.TryAdd(Location.LocationId, Location))
                    {
                        retVal = Location;
                    }
                }
            }
            return retVal;
        }

        /// <summary>
        /// Updates the specified Location, for now if the Location id isn't found
        /// it will return null, but will need more error handling with a real db
        /// </summary>
        /// <param name="Location"></param>
        /// <returns></returns>
        public Location UpdateLocation(Location Location)
        {
            Location retVal = null;
            if (Location != null)
            {
                if (_store.ContainsKey(Location.LocationId))
                {
                    _store[Location.LocationId] = Location;
                    retVal = _store[Location.LocationId];
                }
            }
            return retVal;
        }
        /// <summary>
        /// Return the next available Location id, this would normally be handled by the db
        /// </summary>
        /// <returns></returns>
        private int GetNextHighId()
        {
            return Interlocked.Increment(ref _highId);
        }
    }
}
