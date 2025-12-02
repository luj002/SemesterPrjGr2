public interface IBlogEntryRepository
{
    int Count { get; }
    List<BlogEntry> GetAll();
    void Add(BlogEntry blogEntry);
    Boat? GetBlogEntryById(int id);
    void Remove(int id);
}
