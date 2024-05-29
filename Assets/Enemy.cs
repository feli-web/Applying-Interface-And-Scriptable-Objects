using UnityEngine;

[CreateAssetMenu(fileName ="EnemyScriptable", menuName ="Enemy")]
public class Enemy : ScriptableObject
{
    public string enemyName;
    public int life;
    public string greeting;
    
    public interface Interactuable
    {
        void Action();
        void Inaction();

    }
    public interface Damage
    {
        void TakeDamage(int damage);
    }
}
