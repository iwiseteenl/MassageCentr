using MassageCentr.ActionClass.Account;
using MassageCentr.ActionClass.HelperClass;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MassageCentr.Interface;

namespace MassageCentr.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(IUser iUser) : ControllerBase
    {
        private readonly IUser _IUser = iUser;

        [HttpGet("Persons")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PersonDTO>>> Get() => await Task.FromResult(_IUser.GetPerson());

        [HttpDelete("Persons/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<string>>> Delete(int id) => await Task.FromResult(_IUser.DeletePerson(id));

        [HttpGet("Persons/{name}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PersonDTO>>> Get(string name) => await Task.FromResult(_IUser.GetPerson(name));

        [HttpPost("Persons/addAccount")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<List<string>>> Post(AccountCreate userData) => await Task.FromResult(_IUser.AddAccount(userData));
    }
}

