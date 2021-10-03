using UnityEngine;

namespace AI
{
    [CreateAssetMenu(menuName = "FSM/Action/JumpAction", fileName = "JumpAction")]
    public class JumpAction : Action
    {
        private CharacterController controller;
        
        public override void Initialize()
        {
            controller = FindObjectOfType<CharacterController>();
        }
        
        public override void Execute()
        {
            controller.Jump();
        }
    }
}