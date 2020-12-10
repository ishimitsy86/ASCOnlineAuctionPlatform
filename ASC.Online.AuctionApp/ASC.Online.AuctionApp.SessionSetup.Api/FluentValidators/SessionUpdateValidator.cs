using ASC.Online.AuctionApp.Framework.Models.Models.Session;
using FluentValidation;

namespace ASC.Online.AuctionApp.SessionSetup.Api.FluentValidators
{
    /// <summary>
    /// Auction session update DTO validator
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{AuctionSessionUpdateRequest}" />
    public class SessionUpdateValidator: AbstractValidator<AuctionSessionUpdateRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SessionCreateValidator"/> class.
        /// </summary>
        public SessionUpdateValidator()
        {
            RuleFor(x => x.Id).NotEqual(0);
            RuleFor(x => x.SessionName).NotEmpty();
            RuleFor(x => x.SessionName).MaximumLength(200);
            RuleFor(x => x.SessionDescription).MaximumLength(500);
            RuleFor(x => x.SessionStartDate).NotNull();
            RuleFor(x => x.SessionEndDate).NotNull();           
            RuleFor(x => x.ModifiedBy).NotEmpty();
            RuleFor(x => x.ModifiedDate).NotNull();
            RuleFor(x => x.ModifiedMemberId).NotEqual(0);

        }
    }
}
