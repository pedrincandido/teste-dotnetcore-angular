using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teste.App.Services;
using Teste.App.viewModel;
using Teste.Domain.Entities;

namespace Teste.API.Controllers
{
    public class CrediarioController : Controller
    {
        [HttpGet]
        [Produces(typeof(Crediario))]
        [Route("/crediario/{id}")]
        public IActionResult Get(int id, [FromServices] ContractCrediarioApp contractCrediarioApp)
        {
            try
            {
                return Ok(contractCrediarioApp.GetById(id));
            }
            catch
            {
                return NotFound(id);
            }
        }

        [HttpGet]
        [Produces(typeof(List<Crediario>))]
        [Route("/crediario")]
        public List<CrediarioViewModel> Get([FromQuery]string nome, [FromServices] ContractCrediarioApp contractCrediarioApp)
        {
            try
            {
                return contractCrediarioApp.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        [Route("crediario")]
        public IActionResult Post([FromBody]CrediarioViewModel body, [FromServices] ContractCrediarioApp contractCrediarioApp)
        {
            try
            {
                contractCrediarioApp.SaveCrediario(body);
                return Ok(HttpStatusCode.OK);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("crediario")]
        public IActionResult Put([FromBody]CrediarioViewModel body, [FromServices] ContractCrediarioApp contractCrediarioApp)
        {
            try
            {
                contractCrediarioApp.EditCrediario(body);
                return Ok(HttpStatusCode.OK);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("crediario/{id}")]
        public IActionResult Delete(int id, [FromServices] ContractCrediarioApp contractCrediarioApp)
        {
            if (id > 0)
                contractCrediarioApp.DeleteCrediario(id);

            else
                BadRequest();

            return Ok(HttpStatusCode.OK);
        }
    }
}