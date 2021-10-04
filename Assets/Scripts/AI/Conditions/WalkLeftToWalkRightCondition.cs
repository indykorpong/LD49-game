using UnityEngine;

namespace AI
{
    [CreateAssetMenu(menuName = "FSM/Condition/WalkLeftToWalkRightCondition", fileName = "WalkLeftToWalkRightCondition")]
    public class WalkLeftToWalkRightCondition : Condition
    {
        private bool cachedWillFall;
        private bool currentWillFall;

        public override bool CheckCondition()
        {
            currentWillFall = checker.CharacterWillFallOffCameraView(controller);
            cachedWillFall = currentWillFall;
            
            if (currentWillFall)
            {
                controller.ChangeDirection();
                return true;
            }

            if (!cachedWillFall && !currentWillFall)
            {
                return false;
            }

            return true;
        }
    }
}