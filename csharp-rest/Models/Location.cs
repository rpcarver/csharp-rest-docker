using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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

        [Required]
        [Range(-1, int.MaxValue)]
        public int LocationId { get; set; } = -1;

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        private HashSet<UseType> _Uses = new HashSet<UseType>();

        public bool AddUse(UseType use) => _Uses.Add(use);

        public bool RemoveUse(UseType use) => _Uses.Remove(use);

        public void ClearUses() => _Uses.Clear();

        public List<UseType> GetUses() => _Uses.ToList();
    }
}
