namespace PlayerScripts.StateHandling.States
{
    public class Dead : PlayerState
    {
        public Dead(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine) { }

        public override State  Key      => State.Dead;
        public override string AnimName => "Dead";

        public override void Enter()
        {
            base.Enter();
            // do death stuff
        }
    }
}