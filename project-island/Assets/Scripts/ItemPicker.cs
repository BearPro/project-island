using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPrototype
{
    [RequireComponent(typeof(Collider2D))]
    public class ItemPicker : MonoBehaviour
    {
        public Vector2 pikedPosition;
        private Item picked;
        private void OnTriggerStay2D(Collider2D collision)
        {
            Item item = collision.GetComponent<Item>();
            if (Input.GetKeyDown(KeyCode.E) && item != null)
            {
                if (picked != null)
                {
                    picked.transform.parent = null;
                    picked.PickedState = PickedState.OnGround;
                    var f = picked.GetComponent<Firearm>();
                    if (f != null)
                        f.enabled = false;
                }
                collision.transform.parent = transform;
                collision.transform.localPosition = pikedPosition;
                collision.transform.localRotation = Quaternion.Euler(0, 0, 0);
                item.PickedState = PickedState.InArms;
                var firearm = collision.GetComponent<Firearm>();
                if (firearm != null)
                {
                    firearm.enabled = true;
                }
                picked = item;
            }
        }
    }
}