using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPrototype
{
    public class UserMovement : MonoBehaviour
    {
        [SerializeField]
        private float speed;
        private new Rigidbody2D rigidbody;
        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }
        void Update()
        {
            float dX = Input.GetAxis("Horizontal") * speed;
            float dY = Input.GetAxis("Vertical") * speed;
            Vector3 dPosition = Vector3.ClampMagnitude(new Vector3(dX, dY) * Time.deltaTime, speed);
            if (dPosition != Vector3.zero)
            {
                rigidbody.MovePosition(transform.position + dPosition);
            }
            else
            {

            }
            
        }
    }
}