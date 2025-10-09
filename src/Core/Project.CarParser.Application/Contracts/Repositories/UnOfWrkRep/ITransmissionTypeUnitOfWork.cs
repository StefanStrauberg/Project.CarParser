namespace Project.CarParser.Application.Contracts.Repositories.UnOfWrkRep;

/// <summary>
/// Defines a unit of work interface for managing ITransmissionType repository operations.
/// </summary>
public interface ITransmissionTypeUnitOfWork : IUnitOfWork
{
  ITransmissionTypeRepository TransmissionTypies { get; }
}