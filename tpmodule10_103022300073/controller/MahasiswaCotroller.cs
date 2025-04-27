
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace tpmodule10_103022300073.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class MahasiswaController : ControllerBase
    {
        // Ini adalah list yang akan menyimpan data mahasiswa
        public static List<Mahasiswa> mahasiswaList = new List<Mahasiswa>();

        // GET api/Mahasiswa
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(mahasiswaList);
        }

        // GET api/Mahasiswa/1
        [HttpGet("{Nim}")]
        public IActionResult GetById(string Nim)
        {
            var mahasiswa = mahasiswaList.FirstOrDefault(m => m.Nim == Nim);
            if (mahasiswa == null)
            {
                return NotFound("Mahasiswa tidak ditemukan");
            }
            return Ok(mahasiswa);
        }

        // POST api/Mahasiswa
        [HttpPost]
        public IActionResult Post([FromBody] Mahasiswa mahasiswa)
        {
            if (mahasiswa == null)
            {
                return BadRequest("Data mahasiswa tidak valid");
            }

            mahasiswaList.Add(mahasiswa);

            // Menggunakan 'CreatedAtAction' dengan parameter yang benar
            return CreatedAtAction(nameof(GetById), new { nim = mahasiswa.Nim }, mahasiswa);
        }

        // PUT api/Mahasiswa/1
        [HttpPut("{Nim}")]
        public IActionResult Put(string Nim, [FromBody] Mahasiswa mahasiswa)
        {
            var existingMahasiswa = mahasiswaList.FirstOrDefault(m => m.Nim == Nim);
            if (existingMahasiswa == null)
            {
                return NotFound("Mahasiswa tidak ditemukan");
            }

            existingMahasiswa.Nama = mahasiswa.Nama;
            existingMahasiswa.Nim = mahasiswa.Nim;

            return NoContent(); // Status code 204: No Content
        }

        // DELETE api/Mahasiswa/1
        [HttpDelete("{Nim}")]
        public IActionResult Delete(string Nim)
        {
            var mahasiswa = mahasiswaList.FirstOrDefault(m => m.Nim == Nim);
            if (mahasiswa == null)
            {
                return NotFound("Mahasiswa tidak ditemukan");
            }

            mahasiswaList.Remove(mahasiswa);
            return NoContent(); // Status code 204: No Content
        }
    }

}

