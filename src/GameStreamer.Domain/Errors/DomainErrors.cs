using GameStreamer.Domain.Shared;

namespace GameStreamer.Domain.Errors;

public static class DomainErrors
{
    public static readonly Error CreatorInviting = new Error(
        "GameStreamer.CreatorInviting",
        "Can't send invitation to the Room Creator.");

    public static readonly Error InviteToFullRoom = new Error(
        "GameStreamer.InviteToFullRoom",
        "Can't add Incomer to the Room 'cause it's full already.");

    //public static readonly Error AlreadyPassed = new Error(
    //    "GameStreamer.AlreadyPassed",
    //    "Can't send invitation for game in the past.");

}