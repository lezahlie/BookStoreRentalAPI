using BooksApi.Models;
using BooksApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BooksApi.Controllers
{
    [Route("api/toys")]
    [ApiController]
    public class ToysController : ControllerBase
    {
        private readonly ToyService _toyService;

        public ToysController(ToyService toyService)
        {
            _toyService = toyService;
        }

        [HttpGet]
        public ActionResult<List<Toy>> Get() =>
            _toyService.Get();


        [HttpGet("{id:length(24)}", Name = "GetToy")]
        public ActionResult<Toy> Get(string id)
        {
            var toy = _toyService.Get(id);

            if (toy == null)
            {
                return NotFound();
            }

            return toy;
        }

        [HttpGet("search", Name = "GetToysByCategory")]
        public ActionResult<List<Toy>> GetByCategory(string category)
        {
            var toys = _toyService.GetByCategory(category);
            if (toys== null)
            {
                return NotFound();
            }
          
            return toys;
        }

        [HttpPost]
        public ActionResult<Toy> Create(Toy toy)
        {
            _toyService.Create(toy);

            return CreatedAtRoute("GetToy", new { id = toy.ToyId.ToString() }, toy);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Toy toyIn)
        {
            var toy = _toyService.Get(id);

            if (toy == null)
            {
                return NotFound();
            }

            _toyService.Update(id, toyIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var toy = _toyService.Get(id);

            if (toy == null)
            {
                return NotFound();
            }

            _toyService.Remove(id);

            return NoContent();
        }
    }

}