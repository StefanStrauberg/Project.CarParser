namespace Project.CarParser.Application.Contracts.Mpping;


/// <summary>
/// Defines a mapping configuration for an entity using AutoMapper.
/// </summary>
/// <typeparam name="T">The type to be mapped.</typeparam>
public interface IMapWith<T>
{
  /// <summary>
  /// Configures the mapping profile for the specified type.
  /// </summary>
  /// <param name="profile">The AutoMapper profile where the mapping is registered.</param>
  void Mapping(Profile profile)
    => profile.CreateMap(typeof(T), GetType());
}
