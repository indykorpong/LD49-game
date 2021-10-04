using UnityEngine;

namespace AI
{
    [CreateAssetMenu(menuName = "FSM/Action/ChangeDirectionAction", fileName = "ChangeDirectionAction")]
    public class ChangeDirectionAction : Action
    {
        private CharacterController controller;
        
        public override void Initialize()
        {
            controller = FindObjectOfType<CharacterController>();
        }
        
        public override void Execute()
        {
            controller.ChangeDirection();
        }
    }
}