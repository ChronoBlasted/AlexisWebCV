using System;

public enum ResourceType
{
    None = 0,

    ______UI______ = 400,

    Lock = 403,
    Unlock = 404,
    FloatingText = 405,

    Hard = 406,
    Soft = 407,
    Passion = 408,

    Event = 409,
    ErrorMsg = 410,

    Dev = 411,
    Artist = 412,
    Market = 413,

    Chat = 414,
}

public enum Skills
{
    None = ResourceType.None,
    Hard = ResourceType.Hard,
    Soft = ResourceType.Soft,
    Passion = ResourceType.Passion,
}

public enum Role
{
    None = ResourceType.None,
    Dev = ResourceType.Dev,
    Artist = ResourceType.Artist,
    Market = ResourceType.Market,
}

