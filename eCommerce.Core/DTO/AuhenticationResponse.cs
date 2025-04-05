namespace eCommerce.Core.DTO
{
    public record AuhenticationResponse(
        Guid UserID,
        string? Email,
        string? PersonName,
        string? Gender,
        string? Token,
        bool Success);
    
}
