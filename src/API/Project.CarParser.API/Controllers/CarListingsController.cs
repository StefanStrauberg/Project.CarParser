namespace Project.CarParser.API.Controllers;

public class CarListingsController(ISender sender) : BaseAPIController(sender)
{
  [HttpGet]
  [ProducesResponseType(typeof(IEnumerable<ShortCarListingDTO>), StatusCodes.Status200OK)]
  public async Task<IActionResult> GetCarListingsByFilter([FromQuery] RequestParameters requestParameters,
                                                          CancellationToken cancellationToken)
  {
    var result = await Sender.Send(new GetCarListingsByFilterQuery(requestParameters), cancellationToken);
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
  [ProducesResponseType(typeof(DetailCarListingDTO), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
  public async Task<IActionResult> GetCarListingById(Guid id, CancellationToken cancellationToken)
    => Ok(await Sender.Send(new GetCarListingByIdQuery(id), cancellationToken));

  [HttpPost]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public async Task<IActionResult> CreateCarListing([FromBody] CreateCarListingDTO createCarListingDTO,
                                                    CancellationToken cancellationToken)
    => Ok(await Sender.Send(new CreateCarListingCommand(createCarListingDTO), cancellationToken));

  [HttpPut]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
  public async Task<IActionResult> UpdateCarListing(UpdateCarListingDTO updateCarListingDTO,
                                                    CancellationToken cancellationToken)
    => Ok(await Sender.Send(new UpdateCarListingCommand(updateCarListingDTO), cancellationToken));

  [HttpDelete("{id}")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
  public async Task<IActionResult> DeleteCarListingById(Guid id, CancellationToken cancellationToken)
    => Ok(await Sender.Send(new DeleteCarListingCommand(id), cancellationToken));
}
