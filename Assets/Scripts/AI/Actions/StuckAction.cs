namespace AI
{
    public class StuckAction : Action
    {
        private CharacterController controller;
        
        public override void Initialize()
        {
            controller = FindObjectOfType<CharacterController>();
        }
        
        public override void Execute()
        {
            controller.StayStill();
        }
    }
}