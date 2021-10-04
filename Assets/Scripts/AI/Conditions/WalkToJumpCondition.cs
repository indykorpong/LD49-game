namespace AI
{
    public class WalkToJumpCondition : Condition
    {
        public override bool CheckCondition()
        {
            return checker.CharacterShouldJump(controller);
        }
    }
}