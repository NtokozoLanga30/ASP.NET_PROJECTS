using Microsoft.AspNetCore.Identity;

namespace ComptScienceBooks.Infrastructure
{
    public class CustomerUserValidator: IUserValidator<IdentityUser>
    {
        private static readonly string[] _allowedDomains = new[] { "contoso.com", "acme.com", "example.com" };
        public Task<IdentityResult> ValidateAsync(UserManager<IdentityUser> manager,
            IdentityUser user)
        {
            if (_allowedDomains.Any(domain => user.Email.ToLower().EndsWith($"@{domain}")))
            {
                return Task.FromResult(IdentityResult.Success);
            }
            else
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "EmailDomainError",
                    Description = "Email address domain not allowed"
                }));
            }
        }
    }
}
