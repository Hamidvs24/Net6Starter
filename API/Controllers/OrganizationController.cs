﻿using API.Attributes;
using DTO.Organization;
using DTO.Responses;
using MediatR;
using MEDIATRS.OrganizationCQRS.Commands;
using MEDIATRS.OrganizationCQRS.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using IResult = DTO.Responses.IResult;

namespace API.Controllers;

[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ValidateToken]
public class OrganizationController(IMediator mediator) : Controller
{
    [SwaggerOperation(Summary = "get organizations")]
    [Produces(typeof(IDataResult<List<OrganizationToListDto>>))]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await mediator.Send(new GetOrganizationListQuery());
        return Ok(response);
    }

    [SwaggerOperation(Summary = "get organization")]
    [Produces(typeof(IDataResult<OrganizationToListDto>))]
    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var response = await mediator.Send(new GetOrganizationByIdQuery(id));
        return Ok(response);
    }

    [SwaggerOperation(Summary = "create organization")]
    [Produces(typeof(IResult))]
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Add([FromBody] OrganizationToAddDto request)
    {
        var response = await mediator.Send(new AddOrganizationCommand(request));
        return Ok(response);
    }

    [SwaggerOperation(Summary = "update organization")]
    [Produces(typeof(IResult))]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] OrganizationToUpdateDto request)
    {
        var response = await mediator.Send(new UpdateOrganizationCommand(id, request));
        return Ok(response);
    }

    [SwaggerOperation(Summary = "delete organization")]
    [Produces(typeof(IResult))]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var response = await mediator.Send(new DeleteOrganizationCommand(id));
        return Ok(response);
    }
}