using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using bos.Repositories;
using bos.Models;

/// <summary>
/// Summary description for Location Controlller
/// </summary>
namespace bos.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationRepository _repository;

        public LocationController(ILocationRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Gets a List of locations which can be filtered by optional startsWith
        /// </summary>
        /// <returns>List of locations optionally filtered by startsWith</returns>
        [HttpGet("locations")]
        public IActionResult GetList(string startsWith = null)
        {
            List<Models.Location> Locations = null;
            if (string.IsNullOrEmpty(startsWith))
            {
                Locations = _repository.GetAll();
            }
            else
            {
                Locations = _repository.SearchByName(startsWith);
                if (Locations.Count <= 0)
                {
                    return NotFound($"No Locations names found starting with: {startsWith}");
                }
            }
            return Ok(Locations);
        }

        [HttpGet("locations/{id:int}")]
        public IActionResult GetById(int id)
        {
            Models.Location Location = _repository.GetById(id);
            if(Location != null)
            {
                return Ok(Location);
            } else
            {

                return NotFound($"Location not found with id: {id}");
            }
        }

        /// <summary>
        /// Create an Location from a JSON Body.   For brevity, if a Location with an ID is provided,
        /// a new Location will be created with a NEW ID rather than error or update
        /// </summary>
        /// <param name="Location"></param>
        /// <returns>Created response with the created resource</returns>
        [HttpPost("locations")]
        public IActionResult AddLocation([FromBody] Models.Location Location) 
        {
            Location.LocationId = -1;
            Models.Location result = _repository.AddLocation(Location);
            if( result != null)
            {
                return CreatedAtAction("GetById", new { LocationId = result.LocationId }, result);
            } else
            {
                return StatusCode(500);
            }
        }

        [HttpPut("locations/{id}")]
        public IActionResult UpdateLocation([FromBody] Models.Location Location)
        {
            Models.Location result = _repository.UpdateLocation(Location);
            if( result != null)
            {
                return Ok(result);
            } else
            {
                return NotFound($"Location not found with id: {Location.LocationId}");
            }
        }
    }
}
