using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer _sprite;

    [Header("UI Manager")]
    private UIManager uiManager;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        uiManager = FindObjectOfType<UIManager>();
    }

    public void StopMovement()
    {
        GetComponent<PlayerMovement>().enabled = false;
    }

}
