namespace PlayerScripts.StateHandling.States
{
    public abstract class Alive : PlayerState
    {
        protected Alive(Player.Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine) { }

        public override void Update()
        {
            base.Update();
        }
        
    }
}