namespace AI
{
    public class WalkRightToWalkLeftCondition : Condition
    {
        public override bool CheckCondition()
        {
            return checker.CharacterWillFallOffCameraView(1f, controller);
        }
    }
}