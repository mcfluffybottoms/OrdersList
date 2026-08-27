namespace OrdersList.Models;

public record Address
{
    public long Id { get; init; }
    public string Locality { get; init; } = null!;
    public string StreetAddress { get; init; } = null!;
}

public record Order
{
    public long Id { get; init; }

    public long SenderAddressId { get; init; }
    public Address SenderAddress { get; set; } = null!;
    public long ReceiverAddressId { get; init; }
    public Address ReceiverAddress { get; set; } = null!;

    public long Weight { get; init; } // in grams
    public DateTime PickupDate { get; init; }
    public DateTime CreatedAt { get; init; }
}