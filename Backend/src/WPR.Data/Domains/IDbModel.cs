namespace WPR.Data.Domains;

public interface IDbModel<TDbModel, TBusinessModel>
    where TDbModel : IDbModel<TDbModel, TBusinessModel>
{
    static abstract TDbModel FromBusinessModel(TBusinessModel businessModel);
    TBusinessModel ToBusinessModel();
}