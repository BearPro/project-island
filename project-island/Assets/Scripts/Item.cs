using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPrototype
{
    interface IPickable
    {
        PickedState PickedState { set; }
    }
    public enum PickedState
    {
        OnGround, InArms
    }
    [RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]
    public class Item : MonoBehaviour, IPickable
    {
        [SerializeField]
        private Sprite onGround;
        [SerializeField]
        private Sprite inArms;
        [SerializeField]
        private PickedState pickedState = PickedState.InArms;
        public PickedState PickedState {
            get => pickedState;
            set
            {
                pickedState = value;
                switch (pickedState)
                {
                    case PickedState.InArms:
                        spriteRenderer.sprite = inArms;
                        break;
                    case PickedState.OnGround:
                        spriteRenderer.sprite = onGround;
                        break;
                }
            }
        }
        private SpriteRenderer spriteRenderer;
        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            switch (pickedState)
            {
                case PickedState.InArms:
                    spriteRenderer.sprite = inArms;
                    break;
                case PickedState.OnGround:
                    spriteRenderer.sprite = onGround;
                    break;
            }
        }
    }
}