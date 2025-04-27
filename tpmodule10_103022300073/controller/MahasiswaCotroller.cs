using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace tpmodule10_103022300073.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class MahasiswaController : ControllerBase
    {
        // List mahasiswa
        public static List<Mahasiswa> mahasiswaList = new List<Mahasiswa>();

        // GET api/Mahasiswa
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(mahasiswaList);
        }

        // GET api/Mahasiswa/Index
        [HttpGet("{index:int}")]
        public IActionResult GetByIndex(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
            {
                return NotFound("Index tidak ditemukan");
            }
            return Ok(mahasiswaList[index]);
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

            // Kembalikan data dan index-nya
            int index = mahasiswaList.Count - 1;
            return CreatedAtAction(nameof(GetByIndex), new { index }, mahasiswa);
        }

        // PUT api/Mahasiswa/Index
        [HttpPut("{index:int}")]
        public IActionResult Put(int index, [FromBody] Mahasiswa mahasiswa)
        {
            if (index < 0 || index >= mahasiswaList.Count)
            {
                return NotFound("Index tidak ditemukan");
            }

            mahasiswaList[index].Nama = mahasiswa.Nama;
            mahasiswaList[index].Nim = mahasiswa.Nim;

            return NoContent(); // 204
        }

        // DELETE api/Mahasiswa/Index
        [HttpDelete("{index:int}")]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
            {
                return NotFound("Index tidak ditemukan");
            }

            mahasiswaList.RemoveAt(index);
            return NoContent(); // 204
        }
    }
}
