namespace Character
{
    public struct OnPlayerDeathEvent
    {
        public readonly Player player;

        public OnPlayerDeathEvent(Player player)
        {
            this.player = player;
        }
    }
}
