namespace AI
{
    public class AnyStateToStuckCondition : Condition
    {
        private ConditionChecker checker;
        public override void Initialize()
        {
            checker = FindObjectOfType<ConditionChecker>();
        }

        public override bool CheckCondition()
        {
            return checker.CharacterIsStuck();
        }
    }
}