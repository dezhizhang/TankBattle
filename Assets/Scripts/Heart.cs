using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class Heart : MonoBehaviour
{
    private SpriteRenderer sr;

    public Sprite BrokenSprite;

    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Die()
    {
      sr.sprite = BrokenSprite;
    }
}