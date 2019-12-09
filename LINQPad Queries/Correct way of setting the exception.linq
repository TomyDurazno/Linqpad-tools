<Query Kind="Program" />

void Main()
{
	try
	{	        
		throw new AuthorizationFailedException();
	}
	catch (Exception ex)
	{
		ex.Message.Dump();
	}
}

public class AuthorizationFailedException : Exception
{
	public const string DefaultMessage = "Authentication failed for the DataSource connection. Please verify credentials and try again.";
	public AuthorizationFailedException(string message = DefaultMessage) : base(message)
	{

	}
}

public class AuthorizationFailedException2 : Exception
{
	public new readonly string Message = "Authentication failed for the DataSource connection. Please verify credentials and try again.";
	public AuthorizationFailedException2(string customMessage = null)
	{
		Message = customMessage == null ? Message : customMessage;
	}
}

public class InvalidImageSizeException : Exception
{
	private readonly int _maxHeight;
	private readonly int _maxWidth;

	public override string Message
	{
		get => $"The image size is not valid. Max Width should be { _maxWidth.ToString() } pixels, and Max Height should be { _maxHeight.ToString() } pixels";
	}

	public InvalidImageSizeException(int maxHeight, int maxWidth)
	{
		_maxHeight = maxHeight;
		_maxWidth = maxWidth;
	}
}