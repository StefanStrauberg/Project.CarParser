namespace Project.CarParser.API.Controllers;

public class TransmissionTypesController(ISender sender) : BaseAPIController(sender)
{
  [HttpGet]
  [ProducesResponseType(typeof(IEnumerable<ShortTransmissionTypeDTO>), StatusCodes.Status200OK)]
  public async Task<IActionResult> GetTransmissionTypesByFilter([FromQuery] RequestParameters requestParameters,
                                                                CancellationToken cancellationToken)
  {
    var result = await Sender.Send(new GetTransmissionTypesByFilterQuery(requestParameters), cancellationToken);
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
  [ProducesResponseType(typeof(DetailTransmissionTypeDTO), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
  public async Task<IActionResult> GetTransmissionTypeById(Guid id, CancellationToken cancellationToken)
    => Ok(await Sender.Send(new GetTransmissionTypeByIdQuery(id), cancellationToken));

  [HttpPost]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public async Task<IActionResult> CreateTransmissionType([FromBody] CreateTransmissionTypeDTO createTransmissionTypeDTO,
                                                          CancellationToken cancellationToken)
    => Ok(await Sender.Send(new CreateTransmissionTypeCommand(createTransmissionTypeDTO), cancellationToken));

  [HttpPut]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
  public async Task<IActionResult> UpdateTransmissionType(UpdateTransmissionTypeDTO updateTransmissionTypeDTO,
                                                          CancellationToken cancellationToken)
    => Ok(await Sender.Send(new UpdateTransmissionTypeCommand(updateTransmissionTypeDTO), cancellationToken));

  [HttpDelete("{id}")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
  public async Task<IActionResult> DeleteTransmissionTypeById(Guid id, CancellationToken cancellationToken)
    => Ok(await Sender.Send(new DeleteTransmissionTypeCommand(id), cancellationToken));
}
