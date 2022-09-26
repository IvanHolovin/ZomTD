using System;
using UnityEngine;

namespace InGameScene
{
    public class GameFlowController : MonoBehaviour
    {
        public static GameFlowController Instance;

        public GameState State { get; private set; }
        
        private void Awake()
        {
            Instance = this;
            GameStateUpdater(GameState.PlanningPhase);
        }

        public void GameStateUpdater(GameState newState)
        {
            State = newState;

            switch (State)
            {
                case GameState.PlanningPhase:
                    break;
                case GameState.ShooterPhase:
                    break;
                case GameState.Menu:
                    break;
                case GameState.WaveWon:
                    State = GameState.PlanningPhase;
                    break;
                case GameState.Pause:
                    break;
                case GameState.GameLost:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            GameStateDispatcher.Instance.ActionHappened(State);
        }
    }

    public enum GameState
    {
        PlanningPhase,
        ShooterPhase,
        Menu,
        Pause,
        GameLost,
        WaveWon
    }
    
}