using Exiled.API.Enums;
using Exiled.API.Features;

namespace Martyrdom
{
    public class Main : Plugin<Config>
    {
        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        private Player player;

        public override void OnEnabled()
        {
            base.OnEnabled();
            RegisterEvents();
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            UnRegisterEvents();
        }

        void RegisterEvents()
        {
            player = new Player();
            Exiled.Events.Handlers.Player.Died += player.OnDeath;
        }

        void UnRegisterEvents()
        {
            Exiled.Events.Handlers.Player.Died -= player.OnDeath;
            player = null;
        }
    }
}