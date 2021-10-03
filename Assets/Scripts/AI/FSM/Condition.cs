using UnityEngine;

namespace AI
{
    [CreateAssetMenu(menuName = "FSM/Condition", fileName = "aCondition")]
    public class Condition : ScriptableObject
    {
        public virtual void Initialize(){}

        public virtual bool CheckCondition()
        {
            return false;
        }
    }
}