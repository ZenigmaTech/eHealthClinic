using eHealthClinic.Appointment.Core.Command.Request;
using eHealthClinic.Appointment.Core.Query.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentController : ControllerBase
{


    IMediator _mediator;

    public AppointmentController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] ListAppointmentsRequest request)
    {
        var appointments = await _mediator.Send(request);
        return Ok(appointments);
    }

    [HttpGet("getById")]
    public async Task<IActionResult> Get([FromQuery] GetAppointmentRequest request)
    {
        var appointment = await _mediator.Send(request);
        return Ok(appointment);
    }

    [HttpGet("getTimeslots")]
    public async Task<IActionResult> Get([FromQuery] ListTimeslotsRequest request)
    {
        var timeslots = await _mediator.Send(request);
        return Ok(timeslots);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateAppointmentRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

}

