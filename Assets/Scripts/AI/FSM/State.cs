using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    [CreateAssetMenu(menuName = "FSM/State", fileName = "aState")]
    public class State : ScriptableObject
    {
        public List<Action> actionList;
        public List<Transition> transitionList;
    }
}