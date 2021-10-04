namespace AI
{
    public class AnyStateToStuckCondition : Condition
    {
        public override bool CheckCondition()
        {
            return checker.CharacterIsStuck();
        }
    }
}