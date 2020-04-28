using UnityEngine;

namespace NavGame.Core
{
    //Character events
    public delegate void OnAttackStartEvent();
    public delegate void OnAttackCastEvent (Vector3 casPosition);
    public delegate void OnAttackStrikeEvent(Vector3 position);
    public delegate void OnDamageTakenEvent(Vector3 strikePoint, int amount);
    public delegate void OnHealthChangeEvent(int maxHealth, int currentHealth);
    public delegate void OnDiedEvent();

}