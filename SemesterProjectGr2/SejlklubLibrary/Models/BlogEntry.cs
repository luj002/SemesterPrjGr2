public class BlogEntry
{
    #region Properties
    public string Id { get; }
	public Administrator Author { get; }
	public string Title { get; set; }
	public string Content { get; set; }
	public DateTime CreatedAt { get; }
    #endregion

    #region Constructor
    public BlogEntry(string title, string content, Administrator auther)
	{
		Id = StringId.Next(IdPrefix.BLOGENTRY);
		Title = title;
		Content = content;
		CreatedAt = DateTime.Now;
		Author = auther;
    }
    #endregion

    #region Methods
    public override string ToString()
	{
		return $"BlogEntry {Id}: {Title} by {Author.Name} at {CreatedAt:dd-MM-yyyy | hh:mm}\n{Content}";
	}
    #endregion
}