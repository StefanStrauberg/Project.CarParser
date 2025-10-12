namespace Project.CarParser.API.Controllers;

public class EngineTypesController(ISender sender) : BaseAPIController(sender)
{
  [HttpGet]
  [ProducesResponseType(typeof(IEnumerable<ShortEngineTypeDTO>), StatusCodes.Status200OK)]
  public async Task<IActionResult> GetEngineTypesByFilter([FromQuery] RequestParameters requestParameters,
                                                          CancellationToken cancellationToken)
  {
    var result = await Sender.Send(new GetEngineTypesByFilterQuery(requestParameters), cancellationToken);
    var metadata = new PaginationMetadata()
    {
      TotalCount = result.TotalCount,
      PageSize = result.PageSize,
      CurrentPage = result.CurrentPage,
      TotalPages = result.TotalPages,
      HasNext = result.HasNext,
      HasPrevious = result.HasPrevious
    };
    Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(metadata));
    return Ok(result);
  }

  [HttpGet("{id}")]
  [ProducesResponseType(typeof(DetailEngineTypeDTO), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
  public async Task<IActionResult> GetEngineTypeById(Guid id, CancellationToken cancellationToken)
    => Ok(await Sender.Send(new GetEngineTypeByIdQuery(id), cancellationToken));

  [HttpPost]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public async Task<IActionResult> CreateEngineType([FromBody] CreateEngineTypeDTO createEngineTypeDTO,
                                                    CancellationToken cancellationToken)
    => Ok(await Sender.Send(new CreateEngineTypeCommand(createEngineTypeDTO), cancellationToken));

  [HttpPut]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
  public async Task<IActionResult> UpdateEngineType(UpdateEngineTypeDTO updateEngineTypeDTO,
                                                    CancellationToken cancellationToken)
    => Ok(await Sender.Send(new UpdateEngineTypeCommand(updateEngineTypeDTO), cancellationToken));

  [HttpDelete("{id}")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
  public async Task<IActionResult> DeleteEngineTypeById(Guid id, CancellationToken cancellationToken)
    => Ok(await Sender.Send(new DeleteEngineTypeCommand(id), cancellationToken));
}
