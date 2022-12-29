using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
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
    public void Fail_WithException_ShouldThrowException_WhenExceptionIsNull()
    {
        Exception expectedException = null;
        Func<IResult> failFunction = () => Result.Fail(expectedException);

        failFunction.Should().Throw<ArgumentNullException>();
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
    public void Fail_WithMessage_ShouldThrowException_WhenMessageIsNullOrEmpty()
    {
        const string message = null;

        Func<IResult> failFunction = () => Result.Fail(message);

        failFunction.Should().Throw<ArgumentNullException>();
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
    public void Fail_WithListOfMessages_ShouldThrowException_WhenListOfMessagesIsNull()
    {
        List<string> messages = null;

        Func<IResult> failFunction = () => Result.Fail(messages);

        failFunction.Should().Throw<ArgumentNullException>();
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
    public void Fail_WithExceptionAndMessage_ShouldThrowException_WhenMessageIsNullOrEmpty()
    {
        Exception expectedException = new Exception("Expected message");
        const string message = null;

        Func<IResult> failFunction = () => Result.Fail(expectedException, message);

        failFunction.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void Fail_WithExceptionAndMessage_ShouldThrowException_WhenExceptionIsNull()
    {
        Exception expectedException = null;
        const string message = "My message";

        Func<IResult> failFunction = () => Result.Fail(expectedException, message);

        failFunction.Should().Throw<ArgumentNullException>();
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
    public void Fail_WithExceptionAndListOfMessages_ShouldThrowException_WhenListOfMessagesIsNull()
    {
        Exception expectedException = new Exception("Expected message");
        List<string> messages = null;

        Func<IResult> failFunction = () => Result.Fail(expectedException, messages);

        failFunction.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void Fail_WithExceptionAndListOfMessages_ShouldThrowException_WhenExceptionIsNull()
    {
        Exception expectedException = null;
        List<string> messages = new List<string> { "Message 1", "Message 2" };

        Func<IResult> failFunction = () => Result.Fail(expectedException, messages);

        failFunction.Should().Throw<ArgumentNullException>();
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
    public void Fail_WithDataType_WithException_ShouldThrowException_WhenExceptionIsNull()
    {
        Exception expectedException = null;
        Func<IResult> failFunction = () => Result.Fail<decimal>(expectedException);

        failFunction.Should().Throw<ArgumentNullException>();
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
    public void Fail_WithDataType_WithMessage_ShouldThrowException_WhenMessageIsNullOrEmpty()
    {
        const string message = null;

        Func<IResult> failFunction = () => Result.Fail<decimal>(message);

        failFunction.Should().Throw<ArgumentNullException>();
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
    public void Fail_WithDataType_WithListOfMessages_ShouldThrowException_WhenListOfMessagesIsNull()
    {
        List<string> messages = null;

        Func<IResult> failFunction = () => Result.Fail<decimal>(messages);

        failFunction.Should().Throw<ArgumentNullException>();
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
    public void Fail_WithDataType_WithExceptionAndMessage_ShouldThrowException_WhenMessageIsNullOrEmpty()
    {
        Exception expectedException = new Exception("Expected message");
        const string message = null;

        Func<IResult> failFunction = () => Result.Fail<decimal>(expectedException, message);

        failFunction.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void Fail_WithDataType_WithExceptionAndMessage_ShouldThrowException_WhenExceptionIsNull()
    {
        Exception expectedException = null;
        const string message = "My message";

        Func<IResult> failFunction = () => Result.Fail<decimal>(expectedException, message);

        failFunction.Should().Throw<ArgumentNullException>();
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

    [Fact]
    public void Fail_WithDataType_WithExceptionAndListOfMessages_ShouldThrowException_WhenListOfMessagesIsNull()
    {
        Exception expectedException = new Exception("Expected message");
        List<string> messages = null;

        Func<IResult> failFunction = () => Result.Fail<decimal>(expectedException, messages);

        failFunction.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void Fail_WithDataType_WithExceptionAndListOfMessages_ShouldThrowException_WhenExceptionIsNull()
    {
        Exception expectedException = null;
        List<string> messages = new List<string> { "Message 1", "Message 2" };

        Func<IResult> failFunction = () => Result.Fail<decimal>(expectedException, messages);

        failFunction.Should().Throw<ArgumentNullException>();
    }
}