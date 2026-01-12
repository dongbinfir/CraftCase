using MediatR;
using Microsoft.AspNetCore.Mvc;
using User.Application.UserProfiles.Commands.CreateUserProfile;
using User.Application.UserProfiles.Queries.GetUserProfiles;
using User.Domain.Entities;

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

        /// <summary>
        /// 获取所有商品
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<UserProfile>>> GetUserProfiles()
        {
            var result = await _sender.Send(new GetUserProfilesQuery());
            return Ok(result);
        }

        /// <summary>
        /// 创建商品
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<int>> CreateUserProfile(CreateUserProfileCommand command)
        {
            var id = await _sender.Send(command);
            return CreatedAtAction(nameof(GetUserProfiles), new { id }, id);
        }
    }
}
