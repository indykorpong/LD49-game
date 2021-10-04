using UnityEngine;

namespace AI
{
    [CreateAssetMenu(menuName = "FSM/Condition", fileName = "aCondition")]
    public class Condition : ScriptableObject
    {
        protected ConditionChecker checker;
        protected CharacterController controller;

        public void Initialize()
        {
            checker = FindObjectOfType<ConditionChecker>();
            controller = FindObjectOfType<CharacterController>();
        }

        public virtual bool CheckCondition()
        {
            return false;
        }
    }
}