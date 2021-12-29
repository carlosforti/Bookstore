using Bookstore.Domain.ValueObjects;

using FluentAssertions;

using Flunt.Notifications;

using Xunit;

namespace Bookstore.UnitTests.Domain.ValueObjects
{
    public class NameTests
    {
        private const string ContractName = "Name";
        private const string NotNullOrEmptyErrorMessage = "Name must have a value";
        private const string SizeLimitErrorMessage = "Name must be {0} to {1} characters long";
        private const int MinimumSize = 3;
        private const int MaximumSize = 300;

        [Fact]
        public void CreateName_ShouldBeSuccess_WithoutNotifications()
        {
            var input = "Teste";
            var name = new Name(input);
            name.IsValid.Should().BeTrue();
            name.Notifications.Should().BeEmpty();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CreateName_ShouldFail_WithNotNullOrEmptyErrorMessage(string input)
        {
            var expectedNotification = new Notification(ContractName, NotNullOrEmptyErrorMessage);
            var name = new Name(input);
            name.IsValid.Should().BeFalse();
            name.Notifications.Should().ContainEquivalentOf(expectedNotification);
        }

        [Fact]
        public void CreateName_ShouldFail_WithMaximumSizeLimit()
        {
            var expectedNotification = new Notification(ContractName, string.Format(SizeLimitErrorMessage, MinimumSize, MaximumSize));
            var input = "A".PadRight(MaximumSize + 10, 'A');
            var name = new Name(input);
            name.IsValid.Should().BeFalse();
            name.Notifications.Should().ContainEquivalentOf(expectedNotification);
        }

        [Fact]
        public void CreateName_ShouldFail_WithMinimumSizeLimit()
        {
            var expectedNotification = new Notification(ContractName, string.Format(SizeLimitErrorMessage, MinimumSize, MaximumSize));
            var input = "A";
            var name = new Name(input);
            name.IsValid.Should().BeFalse();
            name.Notifications.Should().ContainEquivalentOf(expectedNotification);
        }

        [Fact]
        public void ParseName_ShouldBeSuccess_WithoutNotifications()
        {
            var name = Name.Parse("Teste");
            name.IsValid.Should().BeTrue();
            name.Notifications.Should().BeEmpty();
        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ParseName_ShouldFail_WithNotNullOrEmptyErrorMessage(string input)
        {
            var expectedNotification = new Notification(ContractName, NotNullOrEmptyErrorMessage);
            var name = Name.Parse(input);
            name.IsValid.Should().BeFalse();
            name.Notifications.Should().ContainEquivalentOf(expectedNotification);
        }

        [Fact]
        public void TryParseName_ShouldBeSuccess_WithoutNotifications()
        {
            var ok = Name.TryParse("Teste", out var name);
            ok.Should().BeTrue();
            name.IsValid.Should().BeTrue();
            name.Notifications.Should().BeEmpty();
        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void TryParseName_ShouldFail_WithNotNullOrEmptyErrorMessage(string input)
        {
            var expectedNotification = new Notification(ContractName, NotNullOrEmptyErrorMessage);
            var ok = Name.TryParse(input, out var name);
            ok.Should().BeFalse();
            name.IsValid.Should().BeFalse();
            name.Notifications.Should().ContainEquivalentOf(expectedNotification);
        }

        [Fact]
        public void ImplicitParseName_ShouldBeSuccess_WithoutNotifications()
        {
            var name = (Name)"Teste";
            name.IsValid.Should().BeTrue();
            name.Notifications.Should().BeEmpty();
        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ImplicitParseName_ShouldFail_WithNotNullOrEmptyErrorMessage(string input)
        {
            var expectedNotification = new Notification(ContractName, NotNullOrEmptyErrorMessage);
            var name = (Name)input;
            name.IsValid.Should().BeFalse();
            name.Notifications.Should().ContainEquivalentOf(expectedNotification);
        }

        [Fact]
        public void ImplicitParseNameToString_ShouldBeSuccess_WithoutNotifications()
        {
            var name = Name.Parse("Teste");
            ((string)name).Should().Be("Teste");
        }

        [Fact]
        public void Equals_ShouldBeTrue_WhenComparingNames()
        {
            var name = new Name("Test");
            var name2 = new Name("Test");

            name.Equals(name2).Should().BeTrue();
        }

        [Fact]
        public void Equals_ShouldBeTrue_WhenComparingString()
        {
            var name = new Name("Test");
            name.Equals("Test").Should().BeTrue();
        }

        [Fact]
        public void Equals_ShouldBeFalse_WhenDifferentNames()
        {
            var name = new Name("Test");
            var name2 = new Name("Test 2");

            name.Equals(name2).Should().BeFalse();
        }

        [Fact]
        public void Equals_ShouldBeFalse_WhenNull()
        {
            var name = new Name("Test");

            name.Equals(null).Should().BeFalse();
        }

        [Fact]
        public void Equals_ShouldBeFalse_WhenNotString()
        {
            var name = new Name("Test");

            name.Equals(1).Should().BeFalse();
        }
    }
}
