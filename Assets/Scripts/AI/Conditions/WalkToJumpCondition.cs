namespace AI
{
    public class WalkToJumpCondition : Condition
    {
        private ConditionChecker checker;
        public override void Initialize()
        {
            checker = FindObjectOfType<ConditionChecker>();
        }

        public override bool CheckCondition()
        {
            return checker.CharacterShouldJump();
        }
    }
}