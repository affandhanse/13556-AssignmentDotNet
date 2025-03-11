using System;

public class PolicyNotFoundException : Exception
{
    public PolicyNotFoundException(string message) : base(message) { }
}