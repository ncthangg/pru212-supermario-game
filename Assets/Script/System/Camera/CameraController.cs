using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // //Follow Player
    // [SerializeField] private Transform Mario;
    // [SerializeField] private float aheadDistance;
    // [SerializeField] private float CameraSpeed;
    // private float lookAhead;

    // private void Update()
    // {
    //     //Follow Player
    //     transform.position = new Vector3(Mario.position.x, Mario.position.y, transform.position.z);
    //     lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * Mario.localScale.x), Time.deltaTime * CameraSpeed);
    // }

    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead = 0;

    public Transform mapBounds;
    private Vector3 minLimit, maxLimit;

    void Start()
    {
        BoxCollider2D bounds = mapBounds.GetComponent<BoxCollider2D>();
        minLimit = bounds.bounds.min;
        maxLimit = bounds.bounds.max;

        player = FindAnyObjectByType<Player>().gameObject.transform;
    }

    private void Update()
    {

        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);

        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);

        // Giới hạn camera
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, minLimit.x, maxLimit.x);
        pos.y = Mathf.Clamp(pos.y, minLimit.y, maxLimit.y);
        transform.position = pos;

    }
}
