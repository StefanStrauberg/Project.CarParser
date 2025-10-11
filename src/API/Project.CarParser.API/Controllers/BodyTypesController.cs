namespace Project.CarParser.API.Controllers;

public class BodyTypesController(ISender sender) : BaseAPIController(sender)
{
  [HttpGet]
  [ProducesResponseType(typeof(IEnumerable<ShortBodyTypeDTO>), StatusCodes.Status200OK)]
  public async Task<IActionResult> GetBodyTypesByFilter([FromQuery] RequestParameters requestParameters,
                                                        CancellationToken cancellationToken)
  {
    var result = await Sender.Send(new GetBodyTypesByFilterQuery(requestParameters), cancellationToken);
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
  [ProducesResponseType(typeof(DetailBodyTypeDTO), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
  public async Task<IActionResult> GetBodyTypeById(Guid id, CancellationToken cancellationToken)
    => Ok(await Sender.Send(new GetBodyTypeByIdQuery(id), cancellationToken));

  [HttpPost]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public async Task<IActionResult> CreateBodyType(CreateBodyTypeCommand createBodyTypeCommand,
                                                  CancellationToken cancellationToken)
    => Ok(await Sender.Send(createBodyTypeCommand, cancellationToken));

  [HttpPut]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
  public async Task<IActionResult> UpdateBodyType(UpdateBodyTypeCommand updateBodyTypeCommand,
                                                  CancellationToken cancellationToken)
    => Ok(await Sender.Send(updateBodyTypeCommand, cancellationToken));

  [HttpDelete("{id}")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
  public async Task<IActionResult> DeleteBodyTypeById(Guid id, CancellationToken cancellationToken)
    => Ok(await Sender.Send(new DeleteBodyTypeCommand(id), cancellationToken));
}
