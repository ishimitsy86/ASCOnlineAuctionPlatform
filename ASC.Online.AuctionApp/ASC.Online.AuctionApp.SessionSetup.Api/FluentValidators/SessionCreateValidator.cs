using ASC.Online.AuctionApp.Framework.Models.Models.Session;
using FluentValidation;

namespace ASC.Online.AuctionApp.SessionSetup.Api.FluentValidators
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{AuctionSessionCreateRequest}" />
    public class SessionCreateValidator:AbstractValidator<AuctionSessionCreateRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SessionCreateValidator"/> class.
        /// </summary>
        public SessionCreateValidator()
        {
            RuleFor(x => x.SessionName).NotEmpty();
            RuleFor(x => x.SessionName).MaximumLength(200);
            RuleFor(x => x.SessionDescription).MaximumLength(500);
            RuleFor(x => x.SessionStartDate).NotNull();
            RuleFor(x => x.SessionEndDate).NotNull();
            RuleFor(x => x.CreatedBy).NotEmpty();
            RuleFor(x => x.CreatedDate).NotNull();
            RuleFor(x => x.CreatedMemberId).NotEqual(0);
            RuleFor(x => x.ModifiedBy).NotEmpty();
            RuleFor(x => x.ModifiedDate).NotNull();
            RuleFor(x => x.ModifiedMemberId).NotEqual(0);
                        
        }
    }
}
