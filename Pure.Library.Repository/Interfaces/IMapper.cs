namespace Pure.Library.Repository.Interfaces;

public interface IMapper<FROM, TO>
{
    public TO Map(FROM source, TO? entity);
}
