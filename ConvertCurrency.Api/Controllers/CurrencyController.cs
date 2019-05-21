using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ConvertCurrency.Domain.Model;
using ConvertCurrency.Services;
using Microsoft.AspNetCore.Mvc;
using ConvertCurrency.Domain.Contracts.Services;


namespace ConvertCurrency.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Currency")]
    public class CurrencyController : Controller
    {
        private ICurrencyServices _services;
        public CurrencyController(ICurrencyServices services)
        {
            _services = services;
        }

        [HttpGet("GetCurrencies")]
        [ProducesResponseType(200, Type = typeof(Currency))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> Get()
        {
            try
            {
                var resultado = await _services.GetAllCurrencies();

                return Ok(resultado);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("ConvertCurrency")]
        [ProducesResponseType(200, Type = typeof(CurrenciesToConvert))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> Post([FromBody] CurrenciesToConvert currencies)
        {
            try
            {
                if (currencies != null)
                {
                    var resultado = await _services.ConvertCurrency(currencies);

                    return Ok(resultado);
                }
                else
                {
                    return BadRequest("Informe os valores");
                }
               

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}