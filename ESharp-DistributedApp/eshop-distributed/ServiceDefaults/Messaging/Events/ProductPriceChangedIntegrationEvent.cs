﻿namespace ServiceDefaults.Messaging.Events;

public record ProductPriceChangedIntegrationEvent: IntegrationEvent
{
    public int ProductId { get; init; } = default!;
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; init; } = default!;
    public string ImageUrl { get; set; } = default!;
}
