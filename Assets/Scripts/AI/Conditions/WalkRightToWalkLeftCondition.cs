namespace AI
{
    public class WalkRightToWalkLeftCondition : Condition
    {
        private ConditionChecker checker;
        public override void Initialize()
        {
            checker = FindObjectOfType<ConditionChecker>();
        }

        public override bool CheckCondition()
        {
            return checker.CharacterWillFallOffCameraView(1f);
        }
    }
}