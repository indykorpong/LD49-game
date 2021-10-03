using UnityEngine;

namespace AI
{
    [CreateAssetMenu(menuName = "FSM/Condition", fileName = "ConditionA")]
    public abstract class Condition : ScriptableObject
    {
        public abstract void Initialize();
        public abstract bool CheckCondition();
    }
}