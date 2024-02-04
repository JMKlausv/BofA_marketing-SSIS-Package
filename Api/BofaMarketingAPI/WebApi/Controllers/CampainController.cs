using Application.Campaigns.Queries.GetCampains;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
   
    public  class CampaignController : ApiControllerBase
    {
       [HttpGet("getCampaignList")]
        public async Task<ActionResult> getAll()
        {
            try
            {
                return Ok(await Mediator.Send(new GetCampainsQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message) ;
            }
        }
         [HttpPost("triggerCampaignSSIS")]
        public async Task<ActionResult> trigger()
        {
            try
            {
                return Ok(await Mediator.Send(new ExecuteSSISPackageCommand()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message) ;
            }
        }
    }
}
