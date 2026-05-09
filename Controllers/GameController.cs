using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MODUL10_103022400116.Model;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using static System.Net.WebRequestMethods;
namespace MODUL10_103022400116.Controllers
{
    // Controller untuk mengelola data game
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        // In-memory list untuk menyimpan data game
        private static List<Game> games = new List<Game>
     {
          // Contoh data game yang sudah ada
        new Game {Id=1, Nama="Valorant", Developer= "Riot Games" , TahunRilis= 2020, Genre= "FPS",
            Rating= 8.5, Platform= ["PC"], Mode= ["Multiplayer"], IsOnline= true, Harga= 0},
        new Game {Id=2, Nama= "GTA V", Developer= "Rockstar Games", TahunRilis= 2013, Genre= "Open World", Rating= 9.5,
            Platform= ["PC", "PS4", "PS5", "Xbox"], Mode= ["Singleplayer",
            "Multiplayer"], IsOnline= true, Harga= 300000},
        new Game {Id=3, Nama= "The Witcher 3", Developer= "CD Projekt Red", TahunRilis= 2015, Genre= "RPG", Rating= 9.7,
            Platform= ["PC", "PS4", "PS5", "Xbox", "Switch"], Mode=
            ["Singleplayer"], IsOnline= false, Harga= 250000}
    };


        // Endpoint untuk mendapatkan semua data game
        [HttpGet]
        public ActionResult<List<Game>> GetAll()
        {
            return games;
        }

        // Endpoint untuk menambahkan data game baru
        [HttpPost]
        public ActionResult AddGame([FromBody] Game game)
        {
            games.Add(game);
            return Ok("Game berhasil ditambahkan");
        }

        // Endpoint untuk mendapatkan data game berdasarkan ID
        [HttpGet("{id}")]
        public ActionResult<Game> GetById(int id)
        {
            // Cek apakah ID valid
            if (id < 0 || id >= games.Count)
            {
                return NotFound("Index tidak ditemukan");
            }
            else// Jika ID valid, kembalikan data game yang sesuai
            {
                return games[id];
            }
        }

        // Endpoint untuk memperbarui data game berdasarkan ID
        [HttpPut("{id}")]
        public ActionResult Update(int id, Game gameUpdate)
        {
            // Cek apakah ID valid
            var index = games.FindIndex(g => g.Id == id);
            // Jika ID tidak ditemukan, kembalikan NotFound
            if (index == -1)
                return NotFound();
            // Jika ID ditemukan, perbarui data game yang sesuai
            games[index] = gameUpdate;
            return Ok(gameUpdate);
        }

        // Endpoint untuk menghapus data game berdasarkan ID
        [HttpDelete("{id}")]
        public ActionResult DeleteFilm(int id)
        {
            // Cek apakah ID valid
            if (id < 0 || id >= games.Count)
                return NotFound("Index tidak ditemukan");
            // Jika ID valid, hapus data game yang sesuai
            games.RemoveAt(id);
            return Ok("Game berhasil dihapus");
        }
    }

}
