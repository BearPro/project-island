using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPrototype.AI
{
    /// <summary>
    /// Заставляет объект "следить" за другим объектом. Верх (локальный Y) будет всегда направлен в сторону курсора.
    /// </summary>
    public class ObjectFollower : MonoBehaviour
    {
        private Quaternion ZeroRotation { get; } = Quaternion.Euler(0, 0, 0);

        public GameObject Target
        { get => target; set => target = value; }
        [SerializeField]
        [Tooltip("Не следовать за объектом")]
        private bool freeze = false;
        [SerializeField]
        private new Rigidbody2D rigidbody;
        [SerializeField]
        [Tooltip("Объект, за которым следует следить")]
        private GameObject target;

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }
        void Update()
        {
            if (!freeze && Target!=null)
            {
                float targetAngle = Mathf.Atan2(x: transform.position.x - Target.transform.position.x,
                                                y: transform.position.y - Target.transform.position.y) * Mathf.Rad2Deg + 90f;
                if (rigidbody == null)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, targetAngle));
                }
                else
                {
                    rigidbody.rotation = targetAngle;
                }
            }
        }
    }
}