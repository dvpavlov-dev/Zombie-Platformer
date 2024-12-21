using System;

public interface IGameProcess
{
    public Action OnGameOver { get; set; }
    public bool IsGameOver { get; set; }
}
