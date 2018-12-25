using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {



    public virtual void ReceiweDamage(Vector3 POZ)
    {
        Damage();
    }
    public virtual void isForce(Vector3 POZ)
    {

    }

    protected virtual void Damage()
    {
        Destroy(gameObject);
    }


}
