namespace AI
{
    public class WalkRightAction : Action
    {
        private CharacterController controller;
        
        public override void Initialize()
        {
            controller = FindObjectOfType<CharacterController>();
        }
        
        public override void Execute()
        {
            controller.WalkRight();
        }
    }
}