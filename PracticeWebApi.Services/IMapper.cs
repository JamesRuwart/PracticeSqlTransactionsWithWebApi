namespace PracticeWebApi.Services
{
    public interface IMapper<TBaseResource, TDataEntity>
    {
        TBaseResource MapToBase(TDataEntity dataEntity);
        TDataEntity MapToDataEntity(TBaseResource baseType);
    }
}
