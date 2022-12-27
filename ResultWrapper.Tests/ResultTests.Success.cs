using FluentAssertions;
using ResultWrapper.Abstractions;
using Xunit;

namespace ResultWrapper.Tests;

public partial class ResultTests
{
    [Fact]
    public void Success_WithoutParameters_ShouldReturnEmptySuccess()
    {
        IResult result = Result.Success();

        result.Should()
            .BeAssignableTo<ISuccessResult>();

        result.Succeeded.Should().BeTrue("ISuccessResult should always have the Succeeded property set to true.");
    }

    [Fact]
    public void Success_WithMessage_ShouldAddMessageToList()
    {
        const string message = "My message";

        IResult result = Result.Success(message);

        result.Should()
            .BeAssignableTo<ISuccessResult>();

        result.Succeeded.Should().BeTrue();
        result.Messages.Should().HaveCount(1).And.Contain(message);
    }

    [Fact]
    public void Success_WithListOfMessages_ShouldSetMessageList()
    {
        List<string> messages = new List<string> { "Message 1", "Message 2" };

        IResult result = Result.Success(messages);

        result.Should()
            .BeAssignableTo<ISuccessResult>();

        result.Succeeded.Should().BeTrue();
        result.Messages.Should().BeEquivalentTo(messages);
    }


    [Fact]
    public void Success_WithData_ShouldSetData()
    {
        const double resultData = 12.5d;

        IResult result = Result.Success(resultData);

        result.Should()
            .BeAssignableTo<ISuccessResult<double>>().And
            .BeEquivalentTo(new { Data = resultData });

        result.Succeeded.Should().BeTrue();
    }

    [Fact]
    public void Success_WithDataAndMessage_ShouldSetDataAndAddMessageToList()
    {
        const string message = "My message";
        const double resultData = 12.5d;

        IResult result = Result.Success(resultData, message);

        result.Should()
            .BeAssignableTo<ISuccessResult<double>>().And
            .BeEquivalentTo(new { Data = resultData });

        result.Succeeded.Should().BeTrue();
        result.Messages.Should().HaveCount(1).And.Contain(message);
    }

    [Fact]
    public void Success_WithDataAndListOfMessage_ShouldSetDataAndMessageList()
    {
        List<string> messages = new List<string> { "Message 1", "Message 2" };
        const double resultData = 12.5d;

        IResult result = Result.Success(resultData, messages);

        result.Should()
            .BeAssignableTo<ISuccessResult<double>>().And
            .BeEquivalentTo(new { Data = resultData });

        result.Succeeded.Should().BeTrue();
        result.Messages.Should().BeEquivalentTo(messages);
    }
}