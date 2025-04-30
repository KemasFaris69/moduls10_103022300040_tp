using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using modul10_103022300040;
using System;

namespace modul10_103022300040.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]

    public class MovieController : ControllerBase
    {
        private static List<Movie> _MovieList = new List<Movie>
        {
            new Movie { Title = "The Shawnshawk Redemption", Director = "Frank Darabont", Stars = 9.3/10, Description = "A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion."},
            new Movie { Title = "The GodFather", Director = "Francis Ford Coppola", Stars = 9.2/10, Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."},
            new Movie { Title = "The Dark Knight", Director = "Christoper Nolan", Stars = 9.0/10, Description = "When a menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman, James Gordon and Harvey Dent must work together to put an end to the madness"},

        };

        [HttpGet]

        public IActionResult Get()
        {
            return Ok(_MovieList);
        }

        [HttpGet("{index}")]

        public IActionResult Get(int index)
        {
            if (index < 0 || index >= _MovieList.Count)
            {
                return NotFound("Movie Tidak Ditemukan");
            }
            return Ok(_MovieList[index]);
        }

        [HttpPost]

        public IActionResult Post([FromBody] Movie movie)

        {
            _MovieList.Add(movie);
            return CreatedAtAction(nameof(Get), new { index = _MovieList.Count - 1 }, movie);
        }

        [HttpPut("{index}")]

        public IActionResult Put(int index, [FromBody] Movie movie)

        {
            if (index < 0 || index >= _MovieList.Count)
            {
                return NotFound("Movie Tidak Ditemukan");
            }

            var Movie = _MovieList[index];
            _MovieList.RemoveAt(index);
            return Ok(movie);
        }

        [HttpDelete("{index}")]

        public IActionResult Delete(int index) 
        {
            if (index < 0 || index >= _MovieList.Count) 
            {
                return NotFound("Movie tidak ditemukan");
            }

            var movie = _MovieList[index];
            _MovieList.RemoveAt(index);
            return Ok(movie);
        }

    }

}
