using UnityEngine;

namespace AI
{
    [CreateAssetMenu(menuName = "FSM/Action/WalkLeftAction", fileName = "WalkLeftAction")]
    public class WalkLeftAction : Action
    {
        private CharacterController controller;
        
        public override void Initialize()
        {
            controller = FindObjectOfType<CharacterController>();
        }
        
        public override void Execute()
        {
            controller.WalkLeft();
        }
    }
}