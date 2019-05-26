using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPrototype.AI
{
    [RequireComponent(typeof(ObjectFollower))]
    public class AIController : MonoBehaviour
    {
        [SerializeField]
        private GameObject weapon;
        private IWeapon weaponComponent;
        private GameObject Target { get; set; }
        private ObjectFollower objectFollower;
        void Start()
        {
            objectFollower = GetComponent<ObjectFollower>();
        }

        void Update()
        {
            FindNearbyTargets();
            objectFollower.Target = Target;
            weaponComponent = weapon.GetComponent<IWeapon>();
        }
        /// <summary>
        /// Осматривает мир вокруг в некотором диапозоне. Если находит игрока - устанавливает его как цель.
        /// </summary>
        void FindNearbyTargets()
        {
            RaycastHit2D[] r = Physics2D.CircleCastAll(transform.position, 1, transform.up);
            foreach (var item in r)
            {
                if (item.transform.tag == "Player")
                {
                    if (Target == null)
                        Target = item.transform.gameObject;
                    else if (weapon != null)
                        weaponComponent.Shoot();
                }

            }
        }
    }
}