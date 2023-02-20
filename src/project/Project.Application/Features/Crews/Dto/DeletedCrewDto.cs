﻿using Core.Application.Dto;

namespace Project.Application.Features.Crews.Dto;

public class DeletedCrewDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Contact { get; set; }
    public string Address { get; set; }
    public string Username { get; set; }
}