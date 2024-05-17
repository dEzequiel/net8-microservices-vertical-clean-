using Catalog.Api.Domain;
using Catalog.Api.Domain.Enums;

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
            1099.99m,
            (int)ProductCategories.MobilePhone
        ),
        new Product(
            new Guid("22222222-2222-2222-2222-222222222222"),
            "Samsung Galaxy Watch 4",
            "The Samsung Galaxy Watch 4 is a stylish and feature-packed smartwatch.",
            249.99m,
            (int)ProductCategories.InteligentDevices
        ),
        new Product(
            new Guid("44444444-4444-4444-4444-444444444444"),
            "Sony WH-1000XM4",
            "The Sony WH-1000XM4 is a top-of-the-line wireless noise-canceling headphone with excellent sound quality and comfort.",
            349.99m,
            (int)ProductCategories.Computer
        ),
        new Product(
            Guid.NewGuid(),
            "Nintendo Switch",
            "The Nintendo Switch is a versatile gaming console that can be played in handheld mode or connected to a TV for home gaming.",
            299.99m,
            (int)ProductCategories.Electronics
        ),
        new Product(
            Guid.NewGuid(),
            "Fitbit Charge 5",
            "The Fitbit Charge 5 is an advanced fitness tracker with built-in GPS, heart rate monitoring, and sleep tracking.",
            179.99m,
            (int)ProductCategories.InteligentDevices
        )

        };
    }
}
