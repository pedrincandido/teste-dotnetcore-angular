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
    public class SaleController : Controller
    {
        [HttpGet]
        [Produces(typeof(Sale))]
        [Route("/sale/{id}")]
        public IActionResult Get(int id, [FromServices] ContractSaleApp contractSaleApp)
        {
            try
            {
                return Ok(contractSaleApp.GetById(id));
            }
            catch
            {
                return NotFound(id);
            }
        }

        [HttpGet]
        [Produces(typeof(List<Sale>))]
        [Route("/sale")]
        public List<Sale> Get([FromQuery]string nome, [FromServices] ContractSaleApp contractSaleApp)
        {
            try
            {
                return contractSaleApp.GetAll(nome);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        [Route("sale")]
        public IActionResult Post([FromBody]SaleViewModel body, [FromServices] ContractSaleApp contractSaleApp)
        {
            try
            {
                contractSaleApp.SaveSale(body);
                return Ok(HttpStatusCode.OK);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("sale")]
        public IActionResult Put([FromBody]SaleViewModel body, [FromServices] ContractSaleApp contractSaleApp)
        {
            try
            {
                contractSaleApp.EditSale(body);
                return Ok(HttpStatusCode.OK);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("sale/{id}")]
        public IActionResult Delete(int id, [FromServices] ContractSaleApp contractSaleApp)
        {
            if (id > 0)
                contractSaleApp.DisableSale(id);

            else
                BadRequest();

            return Ok(HttpStatusCode.OK);
        }
    }
}