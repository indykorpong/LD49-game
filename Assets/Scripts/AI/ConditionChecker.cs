using UnityEngine;

namespace AI
{
    public enum RayDirection{
        RightBelow = 0,
        Down = 1,
        RightAbove = 2
    }
    public class ConditionChecker : MonoBehaviour
    {
        private float cameraMinXViewPort;
        private float cameraMaxXViewPort;

        private Vector2 cameraMinXPosition;
        private Vector2 cameraMaxXPosition;

        [SerializeField] private Camera cam;

        public GameObject[] raycast2DObjects;
        private int objectLayer;

        private CharacterController controller;
        
        private void Start()
        {
            Rect cameraRect = cam.rect;
            cameraMinXViewPort = cameraRect.min.x;
            cameraMaxXViewPort = cameraRect.max.x;

            cameraMinXPosition = cam.ViewportToWorldPoint(new Vector3(cameraMinXViewPort, 0));
            cameraMaxXPosition = cam.ViewportToWorldPoint(new Vector3(cameraMaxXViewPort, 0));

            controller = FindObjectOfType<CharacterController>();
            objectLayer = LayerMask.NameToLayer("Object");
        }

        // 1st condition
        public bool CharacterWillFallOffCameraView(float xAxisDirection, CharacterController controller)
        {
            // return true if the character will fall off from the camera view
            Vector3 characterPosition = controller.CharacterPosition;
            return !(characterPosition.x >= cameraMinXPosition.x && characterPosition.x <= cameraMaxXPosition.x);
        }

        // 2nd condition
        public bool CharacterShouldJump(CharacterController controller)
        {
            // TODO: implement
            // check if the character can jump or not

            float[] raycastDistances = {6.1f, 4.5f};

            int rayIndex = (int) RayDirection.RightBelow;
            bool canJump = CheckPhysics2DRaycast(controller, rayIndex, raycastDistances, objectLayer, true);

            if (canJump)
            {
                rayIndex = (int) RayDirection.Down;
                canJump = CheckPhysics2DRaycast(controller, rayIndex, raycastDistances, objectLayer, false);
                if (!canJump)
                {
                    return false;
                }

                rayIndex = (int) RayDirection.RightAbove;
                canJump = CheckPhysics2DRaycast(controller, rayIndex, raycastDistances, objectLayer, false);
                if (!canJump)
                {
                    return false;
                }
            }
            
            return canJump;
        }

        private bool CheckPhysics2DRaycast(CharacterController controller, int rayIndex, float[] raycastDistances,
            int objectLayer, bool desiredResult)
        {
            bool canJump = false;

            Vector3 rayDirection = controller.raycast2DObjects[rayIndex].transform.right;
            if (Physics2D.Raycast(controller.raycast2DObjects[rayIndex].transform.position, rayDirection,
                raycastDistances[rayIndex], objectLayer))
            {
                canJump = desiredResult;
            }

            return canJump;
        }

        // 3rd condition
        public bool CharacterIsStuck(CharacterController controller)
        {
            // TODO: implement
            // if the character's position doesn't change significantly or changes a little bit
            // or return to the same position repeatedly
            // then he is stuck

            float movementThreshold = 0.01f;

            float movementMagnitude = Vector3.Distance(controller.CharacterPosition, controller.LastFramePosition);
            return movementMagnitude <= movementThreshold;
        }
    }
}