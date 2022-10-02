using DummyCookie.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DummyCookie.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DummyCookieController : ControllerBase
    {
        private readonly IDummyCookieRepository _repository;

        public DummyCookieController(IDummyCookieRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("{userName}", Name = "GetCookie")]
        [ProducesResponseType(typeof(DummyCookie), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<DummyCookie>> GetByName(string userName)
        {
            var basket = await _repository.GetByName(userName);
            return Ok(basket ?? new DummyCookie());
        }

        [HttpPost]
        [ProducesResponseType(typeof(DummyCookie), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<DummyCookie>> Update([FromBody] DummyCookie cookie)
        {

            return Ok(await _repository.Update(cookie));
        }

        [HttpDelete("{userName}", Name = "DeleteCookie")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(string userName)
        {
            await _repository.Delete(userName);
            return Ok();
        }
    }
}