using UnityEngine;

namespace AI
{
    [CreateAssetMenu(menuName = "FSM/Condition/WalkLeftToWalkRightCondition", fileName = "WalkLeftToWalkRightCondition")]
    public class WalkLeftToWalkRightCondition : Condition
    {
        public override bool CheckCondition()
        {
            return checker.CharacterWillFallOffCameraView(-1f, controller);
        }
    }
}