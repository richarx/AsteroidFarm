using System;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private Transform pivot;

    [SerializeField] private float backgroundScrollPower;
    [SerializeField] private float starsScrollPower1;
    [SerializeField] private float starsScrollPower2;
    [SerializeField] private float starsScrollPower3;
    [SerializeField] private float starsScrollPower4;

    [SerializeField] private Material backgroundMaterial;
    [SerializeField] private Material starsMaterial1;
    [SerializeField] private Material starsMaterial2;
    [SerializeField] private Material starsMaterial3;
    [SerializeField] private Material starsMaterial4;
    
    private void LateUpdate()
    {
        Scroll();
    }

    private void Scroll()
    {
        Vector2 position = pivot.position;
        
        backgroundMaterial.mainTextureOffset = position * backgroundScrollPower;
        starsMaterial1.mainTextureOffset = position * starsScrollPower1;
        starsMaterial2.mainTextureOffset = position * starsScrollPower2;
        starsMaterial3.mainTextureOffset = position * starsScrollPower3;
        starsMaterial4.mainTextureOffset = position * starsScrollPower4;
    }

    private void OnApplicationQuit()
    {
        Vector2 zero = Vector2.zero;

        backgroundMaterial.mainTextureOffset = zero;
        starsMaterial1.mainTextureOffset = zero;
        starsMaterial2.mainTextureOffset = zero;
        starsMaterial3.mainTextureOffset = zero;
        starsMaterial4.mainTextureOffset = zero;
    }
}
