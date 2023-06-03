﻿using System.Net.Mime;
using GiftSuggester.Core.Groups.Models;
using GiftSuggester.Core.Groups.Services;
using GiftSuggester.Web.Groups.Mappers;
using GiftSuggester.Web.Groups.Models;
using GiftSuggester.Web.Users.Models;
using Microsoft.AspNetCore.Mvc;

namespace GiftSuggester.Web.Groups.Controllers;

[ApiController]
[Route("groups")]
[Produces(MediaTypeNames.Application.Json)]
public class GroupController
{
    private readonly IGroupService _groupService;
    private readonly GroupWebModelsMapper _mapper;

    public GroupController(IGroupService groupService, GroupWebModelsMapper mapper)
    {
        _groupService = groupService;
        _mapper = mapper;
    }

    [HttpPost]
    public Task AddAsync(GroupCreationRequest creationRequest, CancellationToken cancellationToken)
    {
        return _groupService.AddAsync(
            _mapper.MapCreationRequestToCreationModel(creationRequest),
            cancellationToken);
    }

    [HttpPut("{groupId:guid}/{userId:guid}")]
    public Task AddUserToGroupAsync(Guid groupId, Guid userId, CancellationToken cancellationToken)
    {
        return _groupService.AddUserToGroupAsync(groupId, userId, cancellationToken);
    }

    [HttpGet("{id:guid}")]
    public async Task<GroupResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var group = await _groupService.GetByIdAsync(id, cancellationToken);

        return _mapper.MapGroupToResponse(group);
    }

    [HttpDelete("{id:guid}")]
    public Task RemoveByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _groupService.RemoveByIdAsync(id, cancellationToken);
    }
}