using System;
using System.Linq;
using ACE.Server.Entity;
using ACE.Entity.Enum;
using ACE.Entity.Enum.Properties;

namespace ACE.Server.WorldObjects
{
    /// <summary>
    /// Handles player->monster visibility checks
    /// </summary>
    partial class Player
    {
        /// <summary>
        /// Wakes up any monsters within the applicable range
        /// </summary>
        public void CheckMonsters(float rangeSquared = RadiusAwarenessSquared)
        {
            if (!Attackable) return;

            var visibleObjs = PhysicsObj.ObjMaint.VisibleObjects.Values;

            foreach (var obj in visibleObjs)
            {
                if (PhysicsObj == obj) continue;

                var monster = obj.WeenieObj.WorldObject as Creature;

                if (monster == null || monster is Player) continue;

                if (Location.SquaredDistanceTo(monster.Location) < rangeSquared)
                    AlertMonster(monster);
            }
        }

        /// <summary>
        /// Called when this player attacks a monster
        /// </summary>
        public void OnAttackMonster(Creature monster)
        {
            if (!Attackable) return;

            /*Console.WriteLine($"{Name}.OnAttackMonster({monster.Name})");
            Console.WriteLine($"Attackable: {monster.Attackable}");
            Console.WriteLine($"Tolerance: {monster.Tolerance}");*/

            if (monster.MonsterState != State.Awake && !monster.Tolerance.HasFlag(Tolerance.NoAttack))
            {
                monster.AttackTarget = this;
                monster.WakeUp();
            }
        }
    }
}
