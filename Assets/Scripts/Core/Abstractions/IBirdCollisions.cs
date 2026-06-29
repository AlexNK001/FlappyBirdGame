using System;

public interface IBirdCollisions
{
    event Action ScoreZoneTriggered;
    event Action PlayerDied;
}