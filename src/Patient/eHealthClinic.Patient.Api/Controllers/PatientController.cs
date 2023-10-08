using eHealthClinic.Patient.Core.Command.Request;
using eHealthClinic.Patient.Core.Query.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Patient.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    IMediator _mediator;

    public PatientController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] ListPatientsRequest request)
    {
        var patients = await _mediator.Send(request);
        return Ok(patients);
    }

    [HttpGet("getById")]
    public async Task<IActionResult> Get([FromQuery] GetPatientRequest request)
    {
        var patient = await _mediator.Send(request);
        return Ok(patient);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Get([FromBody] LoginPatientRequest request)
    {
        var patient = await _mediator.Send(request);
        return Ok(patient);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreatePatientRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}

