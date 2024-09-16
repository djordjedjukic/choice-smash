using ChoiceSmash.Enums;
using ChoiceSmash.Models.Responses;
using MediatR;

namespace ChoiceSmash.Features;

public sealed class FindChoices
{
    public record Query : IRequest<HashSet<ChoiceResponse>>;

    internal sealed class Handler : IRequestHandler<Query, HashSet<ChoiceResponse>>
    {
        public Task<HashSet<ChoiceResponse>> Handle(Query request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new HashSet<ChoiceResponse>(Choice.List
                .Select(c => new ChoiceResponse(c.Value, c.Name)).OrderBy(x => x.Id)));
        }
    }
}