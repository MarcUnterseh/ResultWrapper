using FluentAssertions;
using ResultWrapper.Abstractions;
using Xunit;

namespace ResultWrapper.Tests;

public partial class ResultTests
{
    [Fact]
    public void Fail_WithoutParameters_ShouldReturnEmptyFailure()
    {
        IResult result = Result.Fail();

        result.Should()
            .BeAssignableTo<IFailureResult>();

        result.Succeeded.Should().BeFalse();
    }

    [Fact]
    public void Fail_WithException_ShouldSetException()
    {
        Exception expectedException = new Exception("Expected message");

        IResult result = Result.Fail(expectedException);

        result.Should()
            .BeAssignableTo<IFailureResult>().And
            .BeEquivalentTo(new { Exception = expectedException });

        result.Succeeded.Should().BeFalse();
    }

    [Fact]
    public void Fail_WithMessage_ShouldAddMessageToList()
    {
        const string message = "My message";

        IResult result = Result.Fail(message);

        result.Should()
            .BeAssignableTo<IFailureResult>();

        result.Succeeded.Should().BeFalse();
        result.Messages.Should().HaveCount(1).And.Contain(message);
    }

    [Fact]
    public void Fail_WithListOfMessages_ShouldSetMessageList()
    {
        List<string> messages = new List<string> { "Message 1", "Message 2" };

        IResult result = Result.Fail(messages);

        result.Should()
            .BeAssignableTo<IFailureResult>();

        result.Succeeded.Should().BeFalse();
        result.Messages.Should().BeEquivalentTo(messages);
    }

    [Fact]
    public void Fail_WithExceptionAndMessage_ShouldSetExceptionAndAddMessageToList()
    {
        Exception expectedException = new Exception("Expected message");
        const string message = "My message";

        IResult result = Result.Fail(expectedException, message);

        result.Should()
            .BeAssignableTo<IFailureResult>().And
            .BeEquivalentTo(new { Exception = expectedException });

        result.Succeeded.Should().BeFalse();
        result.Messages.Should().HaveCount(1).And.Contain(message);
    }

    [Fact]
    public void Fail_WithExceptionAndListOfMessages_ShouldSetExceptionAndMessageList()
    {
        Exception expectedException = new Exception("Expected message");
        List<string> messages = new List<string> { "Message 1", "Message 2" };

        IResult result = Result.Fail(expectedException, messages);

        result.Should()
            .BeAssignableTo<IFailureResult>().And
            .BeEquivalentTo(new { Exception = expectedException });

        result.Succeeded.Should().BeFalse();
        result.Messages.Should().BeEquivalentTo(messages);
    }

    [Fact]
    public void Fail_WithDataType_ShouldReturnFailureWithCorrespondingType()
    {
        IResult result = Result.Fail<string>();

        result.Should()
            .BeAssignableTo<IFailureResult<string>>();

        result.Succeeded.Should().BeFalse();
    }

    [Fact]
    public void Fail_WithDataType_WithException_ShouldSetException()
    {
        Exception expectedException = new Exception("Expected message");

        IResult result = Result.Fail<string>(expectedException);

        result.Should()
            .BeAssignableTo<IFailureResult<string>>().And
            .BeEquivalentTo(new { Exception = expectedException });

        result.Succeeded.Should().BeFalse();
    }

    [Fact]
    public void Fail_WithDataType_WithMessage_ShouldAddMessageToList()
    {
        const string message = "My message";

        IResult result = Result.Fail<string>(message);

        result.Should()
            .BeAssignableTo<IFailureResult<string>>();

        result.Succeeded.Should().BeFalse();
        result.Messages.Should().HaveCount(1).And.Contain(message);
    }

    [Fact]
    public void Fail_WithDataType_WithListOfMessages_ShouldSetMessageList()
    {
        List<string> messages = new List<string> { "Message 1", "Message 2" };

        IResult result = Result.Fail<string>(messages);

        result.Should()
            .BeAssignableTo<IFailureResult<string>>();

        result.Succeeded.Should().BeFalse();
        result.Messages.Should().BeEquivalentTo(messages);
    }


    [Fact]
    public void Fail_WithDataType_WithExceptionAndMessage_ShouldSetExceptionAndAddMessageToList()
    {
        Exception expectedException = new Exception("Expected message");
        const string message = "My message";

        IResult result = Result.Fail<string>(expectedException, message);

        result.Should()
            .BeAssignableTo<IFailureResult<string>>().And
            .BeEquivalentTo(new { Exception = expectedException });

        result.Succeeded.Should().BeFalse();
        result.Messages.Should().HaveCount(1).And.Contain(message);
    }

    [Fact]
    public void Fail_WithDataType_WithExceptionAndListOfMessages_ShouldSetExceptionAndMessageList()
    {
        Exception expectedException = new Exception("Expected message");
        List<string> messages = new List<string> { "Message 1", "Message 2" };

        IResult result = Result.Fail<string>(expectedException, messages);

        result.Should()
            .BeAssignableTo<IFailureResult<string>>().And
            .BeEquivalentTo(new { Exception = expectedException });

        result.Succeeded.Should().BeFalse();
        result.Messages.Should().BeEquivalentTo(messages);
    }
}