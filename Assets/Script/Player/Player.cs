using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer _sprite;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    public void StopMovement()
    {
        GetComponent<PlayerMovement>().enabled = false;
    }

}
