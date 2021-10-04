namespace AI
{
    public class WalkLeftToWalkRightCondition : Condition
    {
        public override bool CheckCondition()
        {
            return checker.CharacterWillFallOffCameraView(-1f, controller);
        }
    }
}