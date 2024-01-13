using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractWarrior : MonoBehaviour
{
    virtual public void TakeDamage(int damage)
    {
        Debug.Log("damagee");
    }
}
