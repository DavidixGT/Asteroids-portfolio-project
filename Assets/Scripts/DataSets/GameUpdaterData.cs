using System.Collections.Generic;

public class GameUpdaterData
{
    public List<GameBehaviour> GameBehaviours = new List<GameBehaviour>();
    public void TryToAddGameBehaviour(GameBehaviour gameBehaviour)
    {
        if (gameBehaviour != null)
           GameBehaviours.Add(gameBehaviour);
    }
    public void RemoveGameBehaviour(GameBehaviour gameBehaviour)
    {
        GameBehaviours.Remove(gameBehaviour);
    }
}