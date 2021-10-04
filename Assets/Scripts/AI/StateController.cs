using System;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class StateController : MonoBehaviour
    {
        public List<State> stateList;
        [SerializeField] 
        private State currentState;
        public State initialState;
        
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

            currentState = initialState;
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