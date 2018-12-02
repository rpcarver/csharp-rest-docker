using System;
using System.Collections.Generic;

/// <summary>
/// Summary description for a an Location e.g.  hike up to the falls.   
/// Yes this is an overly simplistic example.   Enough from the peanut gallery.
/// </summary>
namespace bos.Models
{
    public class Location
    {

        public Location()
        {
        }

        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // TODO: validate UseTypes
        public List<UseType> Uses { get; set; } = new List<UseType>();

        // rcarver - would be useful to have add/remove UseTypes depending on front end implementation
    }
}
