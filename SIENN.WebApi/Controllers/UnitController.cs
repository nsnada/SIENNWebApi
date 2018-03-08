using Microsoft.AspNetCore.Mvc;
using SIENN.DbAccess.Repositories;
using SIENN.Models;
using System.Collections.Generic;

namespace SIENN.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Unit")]
    public class UnitController : Controller
    {
        private IUnitRepository _unitRepository;

        public UnitController(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        [HttpGet]
        public IEnumerable<UnitEntity> Get()
        {
            return _unitRepository.GetAll();
        }


        [HttpGet("{id}")]
        public UnitEntity Get(int id)
        {
            UnitEntity unit = _unitRepository.Get(id);
            return unit;
        }


        [HttpPost("{description}")]
        public void Create(string description)
        {
            UnitEntity unit = new UnitEntity();
            unit.Description = description;
            _unitRepository.Add(unit);
        }


        [HttpPut("{id}/{description}")]
        public void Update(int id, string description)
        {
            UnitEntity oldUnit = _unitRepository.Get(id);
            if (oldUnit != null)
            {
                oldUnit.Description = description;
                _unitRepository.Update(oldUnit);
            }
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            UnitEntity unit = _unitRepository.Get(id);
            if (unit != null)
                _unitRepository.Remove(unit);
        }
    }
}