using UnityEngine;

namespace AI
{
    public class ConditionChecker : MonoBehaviour
    {
        public bool CharacterWillFallOffCameraView(float xAxisDirection)
        {
            // TODO: implement
            // return true if the character will fall off from the camera view
            return false;
        }

        public bool CharacterShouldJump()
        {
            // TODO: implement
            // if the character collides into an object
            // then he should jump
            return false;
        }

        public bool CharacterIsStuck()
        {
            // TODO: implement
            // if the character's position doesn't change significantly or changes a little bit
            // or return to the same position repeatedly
            // then he is stuck
            return false;
        }
    }
}