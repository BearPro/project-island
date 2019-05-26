using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPrototype {
    public class DestroyOnTime : MonoBehaviour
    {
        [SerializeField]
        private float secondsToAlive;
        void Start()
        {
            StartCoroutine(StartLive());
        }
        IEnumerator StartLive()
        {
            yield return new WaitForSeconds(secondsToAlive);
            Destroy(this.gameObject);
        }
    }
}