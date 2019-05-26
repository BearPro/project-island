using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPrototype
{
    public class SceneController : MonoBehaviour
    {
        public static GameObject Junk { get; private set; }
        [SerializeField]
        private GameObject junk;
        void Start()
        {
            Junk = junk;
        }
    }
}