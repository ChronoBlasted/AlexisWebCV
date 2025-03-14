using System;

public enum ResourceType
{
    None = 0,

    ______UI______ = 400,

    Exp = 401,
    Life = 402,
    Lock = 403,
    Unlock = 404,
    FloatingText = 405,
    Hard = 406,
    Soft = 407,
    Passion = 408,
    Event = 409,
    ErrorMsg = 410,
}

public enum Currency
{
    Exp = ResourceType.Exp,
    Life = ResourceType.Life
}