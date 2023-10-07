namespace PlayerScripts.StateHandling.States
{
    public class Move : Alive
    {
        public Move(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine) { }

        public override State  Key      => State.Move;
        public override string AnimName => "Move";
    }
}