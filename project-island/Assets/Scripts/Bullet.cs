using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPrototype {
    interface IShootable
    {
        float StartSpeed { get; set; }
        float Velocity { get; set; }
    }
    public class Bullet : MonoBehaviour, IShootable
    {

        public float StartSpeed { get => startSpeed; set => startSpeed = value; }
        public float Velocity { get => velocity; set => velocity = value; }
        private float _speed;
        [SerializeField]
        private float startSpeed;
        [SerializeField]
        private float velocity;
        [SerializeField]
        private float mass = 0;
        [SerializeField]
        private GameObject instantiateOnDestroy;
        [SerializeField]
        private int damage = 10;
        void Start()
        {
            _speed = StartSpeed;
        }
        void Update()
        {
            if (_speed < 0)
                Destroy(this.gameObject);
            transform.Translate(0, _speed * Time.deltaTime, 0);
            _speed += Velocity * Time.deltaTime;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag != "B_transparent")
            {
                Debug.Log(collision.tag);
                Destroy(this.gameObject);
                var rigidbody = collision.GetComponent<Rigidbody2D>();
                if (rigidbody != null)
                {
                    var f = transform.TransformDirection(new Vector3(0, mass * _speed, 0));
                    rigidbody.AddForce(new Vector2(f.x, f.y), ForceMode2D.Impulse);
                }
                var health = collision.GetComponent<HealthPlayer>();
                if (health != null)
                {
                    health.Health -= damage;
                }
            }
        }
        private void OnDestroy()
        {
            if (instantiateOnDestroy != null)
            {
                Instantiate(instantiateOnDestroy, transform.position, transform.rotation, SceneController.Junk.transform);
            }
        }
    }
}