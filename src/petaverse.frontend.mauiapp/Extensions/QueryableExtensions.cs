namespace petaverse.frontend.mauiapp;

public static class QueryableExtensions
{
    public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> query, bool condition, Func<T, bool> predicateIftrue)
        => condition ? query.Where(predicateIftrue) : query;
}