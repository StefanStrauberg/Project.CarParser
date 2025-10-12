namespace Project.CarParser.API.Controllers;

public class PlaceRegionsController(ISender sender) : BaseAPIController(sender)
{
  [HttpGet]
  [ProducesResponseType(typeof(IEnumerable<ShortPlaceRegionDTO>), StatusCodes.Status200OK)]
  public async Task<IActionResult> GetPlaceRegionsByFilter([FromQuery] RequestParameters requestParameters,
                                                           CancellationToken cancellationToken)
  {
    var result = await Sender.Send(new GetPlaceRegionsByFilterQuery(requestParameters), cancellationToken);
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
  [ProducesResponseType(typeof(DetailPlaceRegionDTO), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
  public async Task<IActionResult> GetPlaceRegionById(Guid id, CancellationToken cancellationToken)
    => Ok(await Sender.Send(new GetPlaceRegionByIdQuery(id), cancellationToken));

  [HttpPost]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public async Task<IActionResult> CreatePlaceRegion([FromBody] CreatePlaceRegionDTO createPlaceRegionDTO,
                                                     CancellationToken cancellationToken)
    => Ok(await Sender.Send(new CreatePlaceRegionCommand(createPlaceRegionDTO), cancellationToken));

  [HttpPut]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
  public async Task<IActionResult> UpdatePlaceRegion(UpdatePlaceRegionDTO updatePlaceRegionDTO,
                                                     CancellationToken cancellationToken)
    => Ok(await Sender.Send(new UpdatePlaceRegionCommand(updatePlaceRegionDTO), cancellationToken));

  [HttpDelete("{id}")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
  public async Task<IActionResult> DeletePlaceRegionById(Guid id, CancellationToken cancellationToken)
    => Ok(await Sender.Send(new DeletePlaceRegionCommand(id), cancellationToken));
}
