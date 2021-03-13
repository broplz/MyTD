using UnityEngine;

public enum projectileType
{
    rock, arrow, fireball
};
public class Projectile : MonoBehaviour
{
    [SerializeField]
    private int attackDamage;

    [SerializeField]
    private projectileType pType;

    public int AttackDamage
    {
        get
        {
            return attackDamage;
        }
    }

    public projectileType PType
    {
        get
        {
            return pType;
        }
    }
}
