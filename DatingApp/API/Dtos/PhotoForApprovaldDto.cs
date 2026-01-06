using System;

namespace API.Dtos;

public class PhotoForApprovaldDto
{
    public int Id { get; set; }
    public required string Url { get; set; }
    public required string UserId { get; set; }
    public bool IsApproved { get; set; }

}
