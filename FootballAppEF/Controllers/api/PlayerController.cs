using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using FootballAppEF.Models;

namespace FootballAppEF.Controllers
{
    public class PlayerController : ApiController
    {

        FootballTeamDB TeamDB = new FootballTeamDB();
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(TeamDB.Players.ToList());
            }
            catch(SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

       
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                return Ok(await TeamDB.Players.FindAsync(id));
            }
            catch (SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        
        public async Task<IHttpActionResult> Post([FromBody] Player newPlayer)
        {
            try
            {
                TeamDB.Players.Add(newPlayer);
                await TeamDB.SaveChangesAsync();    
                return Ok(TeamDB.Players.ToList());
            }
            catch (SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }

        }

        
        public async Task<IHttpActionResult> Put(int id, [FromBody] Player updated)
        {
            try
            {
                Player foundPlayer = await TeamDB.Players.FindAsync(id);
                foundPlayer.FirstName = updated.FirstName;
                foundPlayer.LastName = updated.LastName;
                foundPlayer.Age = updated.Age;
                foundPlayer.Position = updated.Position;
                await TeamDB.SaveChangesAsync();
                return Ok(TeamDB.Players.ToList());
            }
            catch (SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }


        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                TeamDB.Players.Remove(await TeamDB.Players.FindAsync(id));
                await TeamDB.SaveChangesAsync();
                return Ok(TeamDB.Players.ToList());
            }
            catch (SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }


    }
}
