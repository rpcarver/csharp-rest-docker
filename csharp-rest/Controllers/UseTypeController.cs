using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using bos.Repositories;
using bos.Models;

/// <summary>
/// Summary description for UseType Controlller
/// </summary>
namespace bos.Controllers
{
    public class UseTypeController : Controller
    {
        private readonly IUseTypeRepository _repository;

        public UseTypeController(IUseTypeRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Gets a List of UseTypes, can be filtered by using the optional parameter startsWith
        /// </summary>
        /// <param name="startsWith">Case sensitive search string</param>
        /// <returns>List of UseTypes filtered on Name by the optional case sensitive parameter startsWith</returns>
        [HttpGet("usetypes")] 
        public IActionResult GetList(string startsWith = null)
        {
            List<UseType> UseTypes = null;
            if (string.IsNullOrEmpty(startsWith))
            {
                UseTypes = _repository.GetAll();
            }
            else
            {
                UseTypes = _repository.SearchByName(startsWith);
                if( UseTypes.Count <= 0)
                {
                    return NotFound($"No UseType names found starting with {startsWith}");
                }
            }
            return Ok(UseTypes);
        }
    }
}
