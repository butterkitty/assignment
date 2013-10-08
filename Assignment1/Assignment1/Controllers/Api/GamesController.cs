using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment1.Controllers.Api
{
    [RoutePrefix("api")]
    public class  GamesController : ApiController 
    {
        [HttpGet("Games")]
        public List<Models.DTO.Game> GetGames()
        {
            MichelleEntities context = new MichelleEntities();

            return (from g in context.Games 
                         select new Models.DTO.Game { 
                             id = g.ID,
                             name = g.Name
                         }).ToList();
            
        }
        [HttpPost("games")]
        public Models.DTO.Game AddGame(Models.DTO.Game game)
        {
            MichelleEntities context = new MichelleEntities();

            Game newGame = new Game
            {
                Name = game.name
            };

            context.Games.Add(newGame);
            context.SaveChanges();

            return new Models.DTO.Game
            {
                id = newGame.ID,
                name = newGame.Name
            };
        }
        [HttpPut("games/{id}")]
        public void UpdateGame(int id, Models.DTO.Game gameInfo)
        {
            MichelleEntities context = new MichelleEntities();
            Game game = (from g in context.Games
                         where g.ID == id
                         select g).FirstOrDefault();
            if (game != null)
            {
                game.Name = gameInfo.name;

                context.SaveChanges();

            }

        }
    }

}
