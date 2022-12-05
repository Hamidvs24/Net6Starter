﻿using System.ComponentModel.DataAnnotations;

namespace DTO.User;

public record UserToUpdateDto
{
    [Required] public int UserId { get; set; }
    [Required] public string Email { get; set; }
    [Required] public string ContactNumber { get; set; }
    [Required] public string Username { get; set; }
}