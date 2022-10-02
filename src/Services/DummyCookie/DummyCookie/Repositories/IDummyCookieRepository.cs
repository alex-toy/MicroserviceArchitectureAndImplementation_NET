namespace DummyCookie.Repositories
{
    public interface IDummyCookieRepository
    {
        Task<DummyCookie> GetByName(string name);
        Task<DummyCookie> Update(DummyCookie cookie);
        Task Delete(string name);
    }
}
