using System.Collections.Generic;

namespace PlayerScripts.StateHandling
{
    public class PlayerStateMachine
    {
        private readonly Player.Player                         player;
        public           PlayerState                    CurrentState { get; private set; }
        private readonly Dictionary<State, PlayerState> states = new();

        public PlayerStateMachine(Player.Player player)
        {
            this.player = player;

            foreach (var state in ConstructStates())
            {
                states.Add(state.Key, state);
            }
        }

        public void Initialize(State state)
        {
            CurrentState = states[state];
            CurrentState.Enter();
        }

        public void ChangeState(State state)
        {
            CurrentState.Exit();
            CurrentState = states[state];
            CurrentState.Enter();
        }

        private IEnumerable<PlayerState> ConstructStates()
        {
            var baseType = typeof(PlayerState);
            var assembly = baseType.Assembly;

            foreach (var type in assembly.GetTypes())
            {
                if (type.IsAbstract || !type.IsSubclassOf(baseType))
                    continue;
            
                var constructor = type.GetConstructor(new[] { typeof(Player.Player), typeof(PlayerStateMachine) });

                if (constructor != null)
                {
                    yield return (PlayerState)constructor.Invoke(new object[] { player, this });
                }
            }
        }
    }
}