using UnityEngine;

namespace AI
{
    [CreateAssetMenu(menuName = "FSM/Condition/AnyStateToStuckCondition", fileName = "AnyStateToStuckCondition")]
    public class AnyStateToStuckCondition : Condition
    {
        public override bool CheckCondition()
        {
            return checker.CharacterIsStuck(controller);
        }
    }
}