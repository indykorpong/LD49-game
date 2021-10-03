using UnityEngine;

namespace AI
{
    [CreateAssetMenu(menuName = "FSM/Action/GameOverAction", fileName = "GameOverAction")]
    public class GameOverAction : Action
    {
        private CharacterController controller;
        public override void Initialize()
        {
            controller = FindObjectOfType<CharacterController>();
        }

        public override void Execute()
        {
            controller.GameOver();
        }
    }
}