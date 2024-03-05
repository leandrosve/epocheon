namespace EpochEon.Mappings
{
    public interface IMapperService<TSource, TDestination>
    {
        TDestination Map(TSource source);
    }
}
