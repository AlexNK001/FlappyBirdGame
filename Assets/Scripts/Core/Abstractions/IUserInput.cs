using System;

public interface IUserInput
{
    event Action Jumped;
    event Action Paused;
}