using CaseFacade.Facade.Interfaces;
using CaseFacade.Models;
using Microsoft.AspNetCore.Mvc;

namespace CaseFacade.Controllers;

[ApiController]
[Route("purchase")]
public class PurchaseController : ControllerBase
{
    private readonly IPurchaseFacade _facade;

    public PurchaseController(IPurchaseFacade facade)
    {
        _facade = facade;
    }

    [HttpPost]
    public async Task<IActionResult> Purchase(PurchaseRequest request)
    {
        var result = await _facade.ProcessPurchaseAsync(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}