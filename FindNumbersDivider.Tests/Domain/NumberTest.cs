using FindNumbersDivider.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace FindNumbersDivider.Tests.Domain
{
    [Trait("App Service Tests", "Number")]
    public class NumberTest
    {
        [Fact(DisplayName = "On_Create_ShouldCreateWithoutErrors")]
        public void On_Create_ShouldCreateWithoutErrors()
        {
            // Arrange
            var number = new Number(2);

            // Assert
            number.Algarism.Should().Be(2);
            number.IsValid.Should().BeTrue();
            number.Notifications.Should().BeEmpty();
        }

        [Fact(DisplayName = "On_Create_ShouldCreateWithErrors")]
        public void On_Create_ShouldCreateWithErrors()
        {
            // Arrange
            var number = new Number(-1);

            // Assert
            number.Algarism.Should().Be(-1);
            number.IsValid.Should().BeFalse();
            number.Notifications.Should().NotBeEmpty();
        }

        [Fact(DisplayName = "On_Update_ShouldUpdateWithoutErrors")]
        public void On_Update_ShouldUpdateWithoutErrors()
        {
            // Arrange
            var number = new Number(2);

            // Act
            number.SetAlgarism(5);

            // Assert
            number.Algarism.Should().Be(5);
            number.IsValid.Should().BeTrue();
            number.Notifications.Should().BeEmpty();
        }

        [Fact(DisplayName = "On_Update_ShouldUpdateWithErrors")]
        public void On_Update_ShouldUpdateWithErrors()
        {
            // Arrange
            var number = new Number(2);

            // Act
            number.SetAlgarism(-1);

            // Assert
            number.Algarism.Should().Be(-1);
            number.IsValid.Should().BeFalse();
            number.Notifications.Should().NotBeEmpty();
        }
    }
}