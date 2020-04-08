using UnityEngine;

namespace NavGame.Core
{
    //Character events

    public delegate void OnAttackHitEvent(Vector3 position);
    public delegate void OnDamageTakenEvent(Vector3 strikePoint, int amount);
    public delegate void OnHealthChangeEvent(int maxHealth, int currentHealth);
    public delegate void OnDiedEvent();
}