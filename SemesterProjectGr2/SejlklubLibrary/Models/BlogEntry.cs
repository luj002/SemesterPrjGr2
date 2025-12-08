public class BlogEntry
{
	public string Id { get; }
	public Adminstrator Author { get; }
	public string Title { get; set; }
	public string Content { get; set; }
	public DateTime CreatedAt { get; }
	public BlogEntry(string title, string content, Adminstrator auther)
	{
		Id = StringId.Next("BLOG");
		Title = title;
		Content = content;
		CreatedAt = DateTime.Now;
		Author = auther;
	}
	public override string ToString()
	{
		return $"BlogEntry {Id}: {Title} by {Author.Name} at {CreatedAt:dd-MM-yyyy | hh:mm}\n{Content}";
	}
}