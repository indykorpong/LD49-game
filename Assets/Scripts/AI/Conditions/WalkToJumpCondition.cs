using UnityEngine;

namespace AI
{
    [CreateAssetMenu(menuName = "FSM/Condition/WalkToJumpCondition", fileName = "WalkToJumpCondition")]
    public class WalkToJumpCondition : Condition
    {
        public override bool CheckCondition()
        {
            return checker.CharacterShouldJump(controller);
        }
    }
}