using UnityEngine;

namespace AI
{
    public class ConditionChecker : MonoBehaviour
    {
        private float cameraMinXViewPort;
        private float cameraMaxXViewPort;

        private Vector2 cameraMinXPosition;
        private Vector2 cameraMaxXPosition;
        
        private void Start()
        {
            Camera cam = Camera.current;
            Rect cameraRect = cam.rect;
            cameraMinXViewPort = cameraRect.min.x;
            cameraMaxXViewPort = cameraRect.max.x;

            cameraMinXPosition = cam.ViewportToWorldPoint(new Vector3(cameraMinXViewPort, 0));
            cameraMaxXPosition = cam.ViewportToWorldPoint(new Vector3(cameraMaxXViewPort, 0));
        }
        
        public bool CharacterWillFallOffCameraView(float xAxisDirection, CharacterController controller)
        {
            // return true if the character will fall off from the camera view
            Vector3 characterPosition = controller.characterPosition;
            return !(characterPosition.x >= cameraMinXPosition.x && characterPosition.x <= cameraMaxXPosition.x);
        }

        public bool CharacterShouldJump(CharacterController controller)
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