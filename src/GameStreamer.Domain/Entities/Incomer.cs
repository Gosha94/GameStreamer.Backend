using GameStreamer.Domain.Primitives;
using GameStreamer.Domain.ValueObjects;

namespace GameStreamer.Domain.Entities;

public sealed class Incomer : AggregateRoot
{

    public NickName NickName { get; }

    private Incomer(Guid id, string nickName) : base(id)
    {
        NickName = NickName.Create(nickName).Value;
    }

    public static Incomer Create(NickName nickName)
    {
        return new Incomer(Guid.NewGuid(), nickName.Value);
    }

}