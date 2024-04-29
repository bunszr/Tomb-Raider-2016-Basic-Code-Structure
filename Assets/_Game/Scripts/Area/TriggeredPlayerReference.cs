namespace TriggerableAreaNamespace
{
    public class TriggeredPlayerReference
    {
        public Player Player { get; private set; }

        public void SetPlayer(Player player) => this.Player = player;
    }
}