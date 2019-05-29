using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPrototype
{
    public class PlayerGunController : MonoBehaviour
    {
        [SerializeField]
        GameObject gun;
        IWeapon weapon;
        void Start()
        {
            weapon = gun.GetComponent<IWeapon>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                weapon.Shoot();
            }
        }
    }
}