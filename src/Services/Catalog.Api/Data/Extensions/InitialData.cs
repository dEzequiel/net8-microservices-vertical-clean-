using Catalog.Api.Domain;

namespace Catalog.Api.Data.Extensions
{
    public static class InitialData
    {
        public static IEnumerable<Product> Products => new List<Product>
        {
            new Product(
                new Guid("11111111-1111-1111-1111-111111111111"),
                "iPhone 13 Pro",
                "The iPhone 13 Pro is the latest flagship smartphone from Apple.",
                new List<string> { "Electronics", "Smartphones" },
                999.99m
            ),
            new Product(
                new Guid("22222222-2222-2222-2222-222222222222"),
                "Samsung Galaxy Watch 4",
                "The Samsung Galaxy Watch 4 is a stylish and feature-packed smartwatch.",
                new List<string> { "Electronics", "Wearable Tech" },
                299.99m
            ),
            new Product(
                new Guid("33333333-3333-3333-3333-333333333333"),
                "Nike Air Zoom Pegasus 38",
                "The Nike Air Zoom Pegasus 38 provides responsive cushioning and a secure fit for your runs.",
                new List<string> { "Sports", "Running Shoes" },
                119.99m
            ),
            new Product(
                new Guid("44444444-4444-4444-4444-444444444444"),
                "Sony WH-1000XM4",
                "The Sony WH-1000XM4 is a top-of-the-line wireless noise-canceling headphone with excellent sound quality and comfort.",
                new List<string> { "Electronics", "Headphones" },
                349.99m
            ),
            new Product(
                Guid.NewGuid(),
                "Nintendo Switch",
                "The Nintendo Switch is a versatile gaming console that can be played in handheld mode or connected to a TV for home gaming.",
                new List<string> { "Electronics", "Gaming Consoles" },
                299.99m
            ),
            new Product(
                Guid.NewGuid(),
                "Fitbit Charge 5",
                "The Fitbit Charge 5 is an advanced fitness tracker with built-in GPS, heart rate monitoring, and sleep tracking.",
                new List<string> { "Electronics", "Fitness Trackers" },
                179.95m
            )
        };
    }
}
