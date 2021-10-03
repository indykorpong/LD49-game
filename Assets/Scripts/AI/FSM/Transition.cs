using UnityEngine;

namespace AI
{
    [CreateAssetMenu(menuName = "FSM/Transition", fileName = "aTransition")]
    public class Transition : ScriptableObject
    {
        public Condition condition;
        public State DestStateTrue;
        public State DestStateFalse;

        private StateController stateController;

        public void Initialize()
        {
            stateController = FindObjectOfType<StateController>();
        }
        
        public void PerformTransition()
        {
            if (condition.CheckCondition())
            {
                stateController.ChangeTo(DestStateTrue);
            }
            else
            {
                stateController.ChangeTo(DestStateFalse);
            }
        }
    }
}