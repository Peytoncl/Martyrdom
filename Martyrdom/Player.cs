using System;
using System.Linq;
using Exiled.Events.EventArgs;
using Grenades;
using UnityEngine;
using System.Collections.Generic;
using Mirror;

namespace Martyrdom
{
    public class Player
    {
        public void OnDeath(DiedEventArgs args)
        {
            Exiled.API.Features.Player player = args.Target;
            GrenadeManager grenadeManager = player.ReferenceHub.gameObject.GetComponent<GrenadeManager>();
            GrenadeSettings settings = grenadeManager.availableGrenades.FirstOrDefault(g => g.inventoryID == ItemType.GrenadeFrag);
            Grenade grenade = UnityEngine.Object.Instantiate(settings.grenadeInstance).GetComponent<Grenade>();
            grenade.fuseDuration = 2f;
            grenade.FullInitData(grenadeManager, player.Position, Quaternion.Euler(grenade.throwStartAngle),
                grenade.throwLinearVelocityOffset, grenade.throwAngularVelocity, player.Team);
            NetworkServer.Spawn(grenade.gameObject);
        }
    }
}