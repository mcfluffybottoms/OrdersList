
namespace OrdersList.DTOs;

public record AddressDto(
    string Locality,
    string StreetAddress
);

public record OrderDto(
    long Id,
    AddressDto SenderAddress,
    AddressDto ReceiverAddress,
    long Weight, // in gramms
    DateTime PickupDate
);