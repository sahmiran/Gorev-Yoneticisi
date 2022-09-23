using Gorev_Yoneticisi.Services;
using Gorev_Yoneticisi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gorev_Yoneticisi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : ControllerBase
    {
        private readonly IKullaniciService kullaniciService;

        public KullaniciController(IKullaniciService kullaniciService)
        {
            this.kullaniciService = kullaniciService;
        }
        // GET: api/<KullaniciController>
        [HttpGet("Kullanicilari Listele"),AllowAnonymous]
        public ActionResult<List<Kullanici>> Get()
        {
            return kullaniciService.Get();
        }

        // GET api/<KullaniciController>/5
        [HttpGet("Kullanici Ara"),AllowAnonymous]
        public ActionResult<Kullanici> Get(string id)
        {
            var kullanici = kullaniciService.Get(id);
            if(kullanici == null)
            {
                return NotFound($"Id degeri = {id} olan Kullanici bulunamadi");
            }
            return kullanici;
        }

        // POST api/<KullaniciController>
        [HttpPost("Kullanici Ekle"), Authorize]
        public ActionResult<Kullanici> Post([FromBody] Kullanici kullanici)
        {
            kullaniciService.Create(kullanici);
            return CreatedAtAction(nameof(Get), new { id = kullanici.Id }, kullanici);
        }

        // PUT api/<KullaniciController>/5
        [HttpPut("Kullanici Guncelle"), Authorize]
        public ActionResult Put(string id, [FromBody] Kullanici kullanici)
        {
            var existingKullanici = kullaniciService.Get(id);

            if(existingKullanici == null)
            {
                return NotFound($"Id degeri = {id} olan Kullanici bulunamadi");
            }

            kullaniciService.Update(id, kullanici);
            return NoContent();
        }

        // DELETE api/<KullaniciController>/5
        [HttpDelete("Kullanici Sil"), Authorize]
        public ActionResult Delete(string id)
        {
            var kullanici = kullaniciService.Get(id);

            if (kullanici == null)
            {
                return NotFound($"Id degeri {id} olan Kullanici bulunamadi");
            }

            kullaniciService.Remove(kullanici.Id);
            return Ok($"Id degeri {id} olan Kullanici silindi");
        }
    }
}
