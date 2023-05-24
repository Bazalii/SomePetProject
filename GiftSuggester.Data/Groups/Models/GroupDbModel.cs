﻿using GiftSuggester.Data.Users.Models;

namespace GiftSuggester.Data.Groups.Models;

public class GroupDbModel
{
    public Guid Id { get; set; }
    public Guid OwnerId { get; set; }
    public virtual List<UserDbModel> Members { get; set; } = new();
}