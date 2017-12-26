using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit : MonoBehaviour
{
    public virtual void ResivDameg()
    {
        Die();
    }

    protected void Die()
    {
        Destroy(gameObject);
    }

}
