using Microsoft.AspNetCore.Mvc;
using SIENN.DbAccess.Repositories;
using SIENN.Models;
using System.Collections.Generic;

namespace SIENN.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Type")]
    public class TypeController : Controller
    {
        private ITypeRepository _typeRepository;

        public TypeController(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }


        [HttpGet]
        public IEnumerable<TypeEntity> Get()
        {
            return _typeRepository.GetAll();
        }


        [HttpGet("{id}")]
        public TypeEntity Get(int id)
        {
            TypeEntity tip = _typeRepository.Get(id);
            return _typeRepository.Get(id);
        }


        [HttpPost("{description}")]
        public void Create(string description)
        {
            TypeEntity type = new TypeEntity();
            type.Description = description;
            _typeRepository.Add(type);
        }


        [HttpPut("{id}/{description}")]
        public void Update(int id, string description)
        {
            TypeEntity typeEntity = _typeRepository.Get(id);
            if (typeEntity != null)
            {
                typeEntity.Description = description;
                _typeRepository.Update(typeEntity);
            }
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            TypeEntity type = _typeRepository.Get(id);
            if (type != null)
            {
                _typeRepository.Remove(type);
            }
        }
    }
}