using Itmo.ObjectOrientedProgramming.Lab2.UserModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.ResultModel;

public abstract record InteractionResult
{
    private InteractionResult() { }

    public sealed record AccessSuccess : InteractionResult;

    public sealed record SubjectBuildingSuccess : InteractionResult;

    public sealed record ModifyingAuthorDiscrepancyFailure(User Author) : InteractionResult;

    public sealed record RequiredPointsPaucity(int Points) : InteractionResult;
}