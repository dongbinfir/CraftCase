using User.Application.UserProfiles.Commands.CreateUserProfile;
using User.Application.UserProfiles.Commands.DeleteUserProfile;
using User.Application.UserProfiles.Commands.UpdateUserProfile;
using User.Application.UserProfiles.Dtos;
using User.Application.UserProfiles.Queries.GetUserProfile;
using User.Application.UserProfiles.Queries.GetUserProfiles;
using User.Application.UserProfiles.Queries.SearchUserProfiles;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserProfilesController : ControllerBase
    {
        private readonly ILogger<UserProfilesController> _logger;
        private readonly ISender _sender;

        public UserProfilesController(ILogger<UserProfilesController> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateUserProfileCommand command)
        {
            return await _sender.Send(command);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(DeleteUserProfileCommand command)
        {
            await _sender.Send(command);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateUserProfileCommand command)
        {
            await _sender.Send(command);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<UserProfileBriefDto>> Get(int id)
        {
            return await Mediator.Send(new GetUserProfileQuery() { Id = id });
        }

        [HttpPost("GetList")]
        public async Task<ActionResult<List<UserProfileBriefDto>>> GetList()
        {
            return await _sender.Send(new GetUserProfilesQuery());
        }

        [HttpPost("Search")]
        public async Task<ActionResult<PaginatedList<UserProfileBriefDto>>> Search(SearchUserProfilesQuery query)
        {
            return await _sender.Send(query);
        }
    }
}
