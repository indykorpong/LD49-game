using UnityEngine;

namespace AI
{
    public class Action : ScriptableObject
    {
        public virtual void Initialize(){}
        public virtual void Execute(){}
    }
}