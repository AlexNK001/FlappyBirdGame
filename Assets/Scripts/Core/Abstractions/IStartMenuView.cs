using System;

public interface IStartMenuView : IWindowView, IBestScoreView
{
    event Action StartButtonClicked;
}