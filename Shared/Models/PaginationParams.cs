using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public sealed record PaginationParams
{
    public PaginationParams()
    {
    }

    public PaginationParams(int offset, int limit)
    {
        Limit = limit;
        Offset = offset;
    }

    [Required]
    public int Offset { get; set; }

    [Required]
    public int Limit { get; set; }
}
