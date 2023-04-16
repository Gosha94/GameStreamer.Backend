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

    #region NickName

    public static readonly Error EmptyNickName = new Error(
        "NickName.Empty",
        "NickName is empty.");

    public static readonly Error TooLongNickName = new Error(
        "NickName.TooLong",
        "NickName is too long.");

    #endregion

    #region RoomName

    public static readonly Error EmptyRoomName = new Error(
        "RoomName.Empty",
        "RoomName is empty.");

    public static readonly Error TooLongRoomName = new Error(
        "RoomName.TooLong",
        "RoomName is too long.");

    #endregion

}