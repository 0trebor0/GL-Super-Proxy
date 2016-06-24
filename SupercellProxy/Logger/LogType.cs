﻿using System;

namespace SupercellProxy
{
    enum LogType
    {
        INFO, // A normal text (i.e. "Proxy started")
        WARNING, // A warning (i.e. 2 running proxys)
        CONFIG, // A configuration value
        PACKET, // A client/server packet (i.e. KeepAlive)
        API, // An API message (i.e. "WebAPI started")
        EXCEPTION // An exception (i.e. NullReferenceException)
    }
}
