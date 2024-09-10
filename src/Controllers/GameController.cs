using ChoiceSmash.Features;
using ChoiceSmash.Models.Requests;
using ChoiceSmash.Models.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChoiceSmash.Controllers;

[ApiController]
public class GameController : ControllerBase
{
    private readonly IMediator _mediator;

    public GameController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("choices")]
    public async Task<IActionResult> GetAllChoices()
    {
        HashSet<ChoiceResponse> result = await _mediator.Send(new FindChoices.Query());
        return Ok(result);
    }

    [HttpGet("choice")]
    public async Task<IActionResult> GetRandomChoice() 
    {
        ChoiceResponse result = await _mediator.Send(new FindRandomChoices.Query());
        return Ok(result);
    }

    [HttpPost("play")]
    public async Task<IActionResult> PlayGame([FromBody] PlayRequest request) 
    {
        GameResult result = await _mediator.Send(new PlayGame.Command(request.Player));
        return Ok(result);
    }
}