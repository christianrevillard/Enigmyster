using System.Collections.Generic;
using Enigmyster.Models;
using Enigmyster.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Enigmyster.Controllers
{
    [Route("api/[controller]")]
    public class RiddleController : Controller
    {

        private IDataRepository<Riddle, long> _repository;
        public RiddleController(IDataRepository<Riddle, long> repo)
        {
            _repository = repo;
        }

        [HttpGet]
        public IEnumerable<Riddle> Get()
        {
            return _repository.GetAll();
        }

        [HttpGet("{id}")]
        public Riddle Get(int id)
        {
            return _repository.Get(id);
        }

        [HttpPost]
        public void Post([FromBody]Riddle Riddle)
        {
            _repository.Add(Riddle);
        }

        [HttpPut]
        public void Put([FromBody]Riddle Riddle)
        {
            _repository.Update(Riddle.Id, Riddle);
        }

        [HttpDelete("{id}")]
        public long Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}
