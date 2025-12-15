
public enum RepositoryExceptionType
{
	Create,
	Add,
	Remove,
	Read,
	Update,
	Delete,
	Archive,
}

public class RepositoryException : Exception
{
	public RepositoryExceptionType Type { get; }

	public RepositoryException(RepositoryExceptionType type, string msg)
		: base(msg)
	{
		Type = type;
	}

	public override string Message { get { return $"RepositoryException ({Type}) : {base.Message}"; } }
}

