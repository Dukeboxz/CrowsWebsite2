using CrowsWebsite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CrowsWebsite.Services
{
    public class GameServices
    {
        IConfiguration _iconfiguration;
        private readonly HttpClient client = new HttpClient();
        DbContext db = new websiteContext();


        public GameServices(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }

        public  async Task<List<Game>> GetGameSuggestions(string search)
        {
            string apiUrl = CreateUrl(search);

            List<Game> games =  await MakeHttpRequest(apiUrl) as List<Game>;

            return games;
        }

        public string CreateUrl(string search)
        {
            string baseurl = _iconfiguration.GetValue<string>( "boardGameApiUrl");
            string id = _iconfiguration["BGApiKey"];

       
            return baseurl + search + "&client_id=" + id + "&limit=6";
        }

        public async Task<List<Game>> MakeHttpRequest( string url)
        {
            var stringTask = client.GetStringAsync(url);

            string msg = stringTask.Result.ToString();

            List<Game> games = DeserializeJsonToGames(msg);
            int test = 5;

            return games;
        }

        public List<Game> DeserializeJsonToGames(string jsonString)
        {
            List<Game> games = new List<Game>();
            using(JsonDocument document = JsonDocument.Parse(jsonString))
            {
                JsonElement root = document.RootElement;
                JsonElement gameElement = root.GetProperty("games");

                foreach(JsonElement game in gameElement.EnumerateArray())
                {
                    try
                    {
                        Game newGame = new Game();
                        
                        if (game.TryGetProperty("id", out JsonElement idElement))
                        {

                            newGame.ApiId = idElement.ToString();
                        }
                        if (game.TryGetProperty("name", out JsonElement nameElement))
                        {
                            newGame.name = nameElement.ToString();
                        }

                        if (game.TryGetProperty("min_players", out JsonElement minPlayerElement))
                        {
                            int minPlayerTemp;
                            bool minPlayerConverted = Int32.TryParse(minPlayerElement.ToString(), out minPlayerTemp);
                            newGame.min_players =minPlayerConverted ? minPlayerTemp : 0 ;
                        }
                        if (game.TryGetProperty("max_players", out JsonElement maxPlayerElement))
                        {
                            int maxPlayerTemp; 
                            bool maxPlayerConverted = Int32.TryParse(maxPlayerElement.ToString(), out maxPlayerTemp);
                            newGame.max_players = maxPlayerConverted ? maxPlayerTemp : 0; 
                        }
                        if (game.TryGetProperty("min_playtime", out JsonElement minPlayTimeElement))
                        {
                            int minPlayTemp;
                            bool minplayTimeConverted = Int32.TryParse(minPlayerElement.ToString(), out minPlayTemp); 
                            newGame.min_playtime = minplayTimeConverted ? minPlayTemp: 0;
                        }
                        if (game.TryGetProperty("max_playtime", out JsonElement maxPlayTimeElement))
                        {
                            int maxPlayTemp;
                            bool maxPlayTimeConverted = Int32.TryParse(maxPlayTimeElement.ToString(), out maxPlayTemp);
                            newGame.max_playtime = maxPlayTimeConverted ? maxPlayTemp : 0;
                        }

                        if (game.TryGetProperty("image_url", out JsonElement imageUrlElement))
                        {
                            newGame.img_url = imageUrlElement.ToString();
                        }

                        if (game.TryGetProperty("url", out JsonElement ruleUrlElement))
                        {
                            newGame.rules_url = ruleUrlElement.ToString();
                        }



                        games.Add(newGame);
                    }catch(Exception e)
                    {
                        int tet = 5;
                    }
                }
            }

            return games;
        }

        public List<Game> SaveGamesToDatabase(List<Game> games)
        {
            using(var dbo = new websiteContext())
            {
                foreach (Game game in games)
                {
                    int test = 5;
                    Game gameExists = dbo.Games.FirstOrDefault(g => g.ApiId == game.ApiId); 

                    if(gameExists is null)
                    {
                        dbo.Games.Add(game);
                    }
                    else
                    {
                        game.GameId = gameExists.GameId;
                    }
                }

                dbo.SaveChanges();

                return games;
            }
           

            
        }

        public void LinkGamesOwnedToMember(Member member)
        {
            try
            {
                using (var dbo = new websiteContext())
                {
                    foreach (Game game in member.OwnedGames)
                    {
                        MemberOwnedGames exists = dbo.MemberOwnedGames.FirstOrDefault(x => x.MemberId == member.MemberId && x.GameId == game.GameId);

                        if (exists is null)
                        {
                            MemberOwnedGames newRecord = new MemberOwnedGames();
                            //newRecord.Member = member;
                            newRecord.MemberId = member.MemberId;
                           // newRecord.Game = game;
                            newRecord.GameId = game.GameId;

                            dbo.MemberOwnedGames.Add(newRecord);
                        }
                    }

                    dbo.SaveChanges();
                }
            } catch (Exception e)
            {
                throw new Exception("Couold not save MemberGamesOwned");
             }
        }
    }
}
