public interface IBlogEntryRepository
{
    int Count { get; }
    List<BlogEntry> GetAll();
    void Add(BlogEntry blogEntry);
    BlogEntry? GetBlogEntryById(int id);
    void Remove(int id);
}
