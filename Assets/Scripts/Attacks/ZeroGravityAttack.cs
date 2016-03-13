using Assets.Scripts.Timers;
using System;
using UnityEngine;

namespace Assets.Scripts.Attacks
{
    public class ZeroGravityAttack : GravityAttack
    {
        protected override void Affect(GameObject g)
        {
            Rigidbody rigidbody = g.transform.root.GetComponent<Rigidbody>();
            if (rigidbody)
            {
                rigidbody.useGravity = false;
            }
        }

        protected override void Unaffect(GameObject g)
        {
            Rigidbody rigidbody = g.transform.root.GetComponent<Rigidbody>();
            if (rigidbody)
            {
                rigidbody.useGravity = true;
            }
        }
    }
}
