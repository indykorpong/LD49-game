using UnityEngine;

namespace AI
{
    [CreateAssetMenu(menuName = "FSM/Action/WalkRightAction", fileName = "WalkRightAction")]
    public class WalkRightAction : Action
    {
        private CharacterController controller;
        
        public override void Initialize()
        {
            controller = FindObjectOfType<CharacterController>();
        }
        
        public override void Execute()
        {
            controller.WalkRight();
        }
    }
}