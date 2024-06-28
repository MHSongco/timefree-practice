using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using timefree_training_api.Adapters;
using timefree_training_api.Models.EF.Training;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace timefree_training_api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        // GET: /<controller>/
        [HttpGet]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        //[ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTest()
        {
            try
            {
                var userAdapter = new UserAdapter();
                return Ok(await userAdapter.GetTest());
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<user>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        //[ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var userAdapter = new UserAdapter();
                return Ok(await userAdapter.GetUsers());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<user>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        //[ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUser(string first_name)
        {
            try
            {
                var userAdapter = new UserAdapter();
                return Ok(await userAdapter.GetUser(first_name));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

