namespace Project.CarParser.API.Controllers;

public class PlaceCitiesController(ISender sender) : BaseAPIController(sender)
{
  [HttpGet]
  [ProducesResponseType(typeof(IEnumerable<ShortPlaceCityDTO>), StatusCodes.Status200OK)]
  public async Task<IActionResult> GetPlaceCitiesByFilter([FromQuery] RequestParameters requestParameters,
                                                          CancellationToken cancellationToken)
  {
    var result = await Sender.Send(new GetPlaceCitiesByFilterQuery(requestParameters), cancellationToken);
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
  [ProducesResponseType(typeof(DetailPlaceCityDTO), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
  public async Task<IActionResult> GetPlaceCityById(Guid id, CancellationToken cancellationToken)
    => Ok(await Sender.Send(new GetPlaceCityByIdQuery(id), cancellationToken));

  [HttpPost]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public async Task<IActionResult> CreatePlaceCity([FromBody] CreatePlaceCityDTO createPlaceCityDTO,
                                                   CancellationToken cancellationToken)
    => Ok(await Sender.Send(new CreatePlaceCityCommand(createPlaceCityDTO), cancellationToken));

  [HttpPut]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
  public async Task<IActionResult> UpdatePlaceCity(UpdatePlaceCityDTO updatePlaceCityDTO,
                                                   CancellationToken cancellationToken)
    => Ok(await Sender.Send(new UpdatePlaceCityCommand(updatePlaceCityDTO), cancellationToken));

  [HttpDelete("{id}")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
  public async Task<IActionResult> DeletePlaceCityById(Guid id, CancellationToken cancellationToken)
    => Ok(await Sender.Send(new DeletePlaceCityCommand(id), cancellationToken));
}
