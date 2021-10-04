using UnityEngine;

namespace AI
{
    [CreateAssetMenu(menuName = "FSM/Condition/WalkRightToWalkLeftCondition", fileName = "WalkRightToWalkLeftCondition")]
    public class WalkRightToWalkLeftCondition : Condition
    {
        public override bool CheckCondition()
        {
            return checker.CharacterWillFallOffCameraView(1f, controller);
        }
    }
}