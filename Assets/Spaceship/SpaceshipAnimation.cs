using System;
using UnityEngine;

namespace Spaceship
{
    public class SpaceshipAnimation : MonoBehaviour
    {
        [Header("Sprite Renderers")]
        [SerializeField] private SpriteRenderer spaceshipGraphics;
        
        [Header("Boosters")]
        [SerializeField] private Animator boosterLeft;
        [SerializeField] private Animator boosterRight;

        [Header("Spaceship Sprites")]
        [SerializeField] private Sprite stopped;
        [SerializeField] private Sprite forward;
        [SerializeField] private Sprite right;
        [SerializeField] private Sprite left;

        [SerializeField] private float moveSpeedThreshold;
        [SerializeField] private float rotationSpeedThreshold;
        
        public void UpdateSpaceshipVisuals(Vector2 moveVelocity, float rotationVelocity)
        {
            if (Mathf.Abs(rotationVelocity) >= rotationSpeedThreshold)
            {
                bool isMovingLeft = Mathf.Sign(rotationVelocity) >= 0;
                spaceshipGraphics.sprite = isMovingLeft ? left : right;
                
                SetBoosterState(boosterLeft, !isMovingLeft);
                SetBoosterState(boosterRight, isMovingLeft);
            }
            else
            {
                bool isMovingForward = moveVelocity.magnitude >= moveSpeedThreshold;
                
                spaceshipGraphics.sprite = isMovingForward ? forward : stopped;
                SetBoosterState(boosterLeft, isMovingForward);
                SetBoosterState(boosterRight, isMovingForward);
            }
        }

        private void SetBoosterState(Animator booster, bool state)
        {
            booster.Play(state ? "Booster_Idle" : "Booster_Off");
        }

        public void ResetBooster()
        {
            SetBoosterState(boosterLeft, false);
            SetBoosterState(boosterRight, false);
        }
    }
}
