using UnityEngine;

namespace AI
{
    [CreateAssetMenu(menuName = "FSM/Action", fileName = "ActionA")]
    public abstract class Action : ScriptableObject
    {
        public abstract void Initialize();
        public abstract void Execute();
    }
}