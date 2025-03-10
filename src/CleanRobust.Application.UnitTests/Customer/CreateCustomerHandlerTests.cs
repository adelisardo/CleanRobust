using Xunit;
using Xunit.Categories;

namespace CleanRobust.Application.UnitTests.Customer;

[UnitTest]
public class CreateCustomerHandlerTests
{
    [Fact]
    public async Task Add_ValidCommand_ShouldReturnsCreatedResult()
    {

    }


    [Fact]
    public async Task Add_DuplicateEmailCommand_ShouldReturnsFailResult()
    {

    }

    [Fact]
    public async Task Add_InvalidCommand_ShouldReturnsFailResult()
    {
    }
}
