using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPrototype
{
    enum FireMode
    {
        Automatic,
        Manual
    }
    public class Firearm : MonoBehaviour, IWeapon
    {
        [SerializeField]
        private GameObject bulletPrefab;
        [SerializeField]
        private float shotDelay;
        [SerializeField]
        private FireMode fireMode;
        private float elapsedFromShot = 0;
        void Update()
        {
            if (elapsedFromShot != 0)
                elapsedFromShot += Time.deltaTime;
            if (elapsedFromShot > shotDelay)
                elapsedFromShot = 0;
            if (elapsedFromShot == 0)
                switch (fireMode)
                {
                    case FireMode.Automatic:
                        if (Input.GetMouseButton(0))
                            Shoot();
                        break;
                    case FireMode.Manual:
                        if (Input.GetMouseButtonDown(0))
                            Shoot();
                        break;
                }
        }
        public void Shoot()
        {
            Debug.DrawRay(transform.position, transform.up);
            var b = GameObject.Instantiate(original: bulletPrefab, 
                                           //position: transform.TransformPoint(transform.localPosition), 
                                           position: transform.position,
                                           rotation: transform.rotation, 
                                           parent:   SceneController.Junk.transform);
            Debug.Log($"Bullet position: {b.transform.position}; Weapon position: {transform.position}; Weapon up: {transform.up}");
            elapsedFromShot = 0.000001f;
        }
    }
    public interface IWeapon
    {
        void Shoot();
    }
}