using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPrototype
{
    /// <summary>
    /// Заставляет объект "следить" за курсором мыши. Верх (локальный Y) будет всегда направлен в сторону курсора.
    /// </summary>
    public class MouseFollower : MonoBehaviour
    {
        private Quaternion ZeroRotation { get; } = Quaternion.Euler(0, 0, 0);
        [SerializeField]
        [Tooltip("Не следовать за мышью")]
        private bool freeze = false;
        [SerializeField]
        [Tooltip("Камера")]
        private Camera _camera;
        private new Rigidbody2D rigidbody;
        private void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            if (_camera == null)
            {
                _camera = Camera.main;
            }
        }
        void Update()
        {
            if (!freeze)
            {
                Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
                float targetAngle = Mathf.Atan2(x: transform.position.x - mousePosition.x,
                                                y: transform.position.y - mousePosition.y) * Mathf.Rad2Deg + 90f;
                if (rigidbody == null)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, targetAngle));
                }
                else
                {
                    rigidbody.rotation = targetAngle;
                }
                _camera.transform.rotation = ZeroRotation;
            }
        }
    }
}