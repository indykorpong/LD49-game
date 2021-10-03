using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class StateController : MonoBehaviour
    {
        public List<State> stateList;
        public State currentState;
        
        private void Start()
        {
            foreach (State state in stateList)
            {
                foreach (Action action in state.actionList)
                {
                    action.Initialize();
                }

                foreach (Transition transition in state.transitionList)
                {
                    transition.Initialize();
                    transition.condition.Initialize();
                }
            }
        }

        private void Update()
        {
            foreach (Action action in currentState.actionList)
            {
                action.Execute();
            }
        }

        public void ChangeTo(State destState)
        {
            currentState = destState;
        }
    }
}