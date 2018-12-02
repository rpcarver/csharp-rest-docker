using bos.Models;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Summary description for UseType Repository
/// NOTE: For this exercise, the data is all static, we would probably want to be able to add/remove/update UseTypes.
/// </summary>
namespace bos.Repositories
{
    public class UseTypeRepository : IUseTypeRepository
    {
        private static ConcurrentDictionary<int, UseType> _store = new ConcurrentDictionary<int, UseType>()
        {
            [1] = new UseType(1, "Hiking", "All about da feet"),
            [2] = new UseType(2, "Mountain Bikng", "Keep the round side down"),
            [3] = new UseType(3, "Horse Riding", "Fred'll carry it"),
            [4] = new UseType(4, "Backpacking", "How much are you going to carry?"),
            [5] = new UseType(5, "Trail Running", "As long as its not with those toe shoe things."),
            [6] = new UseType(6, "Fishing", "mmmm..."),
        };
        public UseTypeRepository()
        {
        }

        public List<UseType> GetAll() => _store.Values.ToList();

        /// <summary>
        /// Returns all Use Types that start with the startsWith
        /// </summary>
        /// <param name="startsWith"></param>
        /// <returns></returns>
        public List<UseType> SearchByName(string startsWith)
        {
            List<UseType> retVal = new List<UseType>();
            if (startsWith != null)
            {
                retVal = _store.Values.Where(item => item.Name.StartsWith(startsWith)).ToList();
            }
            return retVal;
        }

        // rcarver - for brevity skip the id getter and other methods, we won't use them for this exercise
    }
}
