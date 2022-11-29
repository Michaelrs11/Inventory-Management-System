namespace IMS.BE.Services
{
    public class UserIdentityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserIdentityService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Gets the user account ID based on claim type <seealso cref="ClaimTypes.NameIdentifier"/>.
        /// </summary>
        public string UserCode => _httpContextAccessor.HttpContext
                                            .User
                                            .Claims
                                            .Select(Q => Q.Value)
                                            .FirstOrDefault();
    }
}
