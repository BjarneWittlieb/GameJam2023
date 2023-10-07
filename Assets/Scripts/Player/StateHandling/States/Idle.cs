namespace PlayerScripts.StateHandling.States
{
    public class Idle : Alive
    {
        public Idle(Player.Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine) { }

        public override State Key      => State.Idle;
        public override string   AnimName => "Idle";

        public override void Update()
        {
            base.Update();
        }
    }
}