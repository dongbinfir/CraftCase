namespace User.Application.UserProfiles.Commands.CreateUserProfile
{
    public record CreateUserProfileCommand : IRequest<int>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

    public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateUserProfileCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
            // 创建实体
            var entity = new UserProfile
            {
                Email = request.Email,
                Password = request.Password,
            };

            // 添加到数据库
            _context.Set<UserProfile>().Add(entity);

            // 保存更改
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
