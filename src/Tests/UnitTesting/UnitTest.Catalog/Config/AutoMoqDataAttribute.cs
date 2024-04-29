using AutoFixture;
using AutoFixture.Xunit2;


namespace UnitTest.Catalog.Config
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            : base(() => new Fixture().Customize(new AutoFixtureCustomization())) { }
    }
}
