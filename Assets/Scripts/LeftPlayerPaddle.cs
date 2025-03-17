using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPlayerPaddle : MonoBehaviour
{
    public float speed = 5.0f;
    
    [Header("LeftControls")]
    public KeyCode keyCodeLeftPlayerUp = KeyCode.W;
    public KeyCode keyCodeLeftPlayerDown = KeyCode.S;

    public bool isPlayer = false;
    public Vector3 newPosition = new Vector3(-7f, 0f, 0f);
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        if (isPlayer)
        {
            spriteRenderer.color = SaveControllerPong.Instance.colorPlayer;
        }
        else
        {
            spriteRenderer.color = SaveControllerPong.Instance.colorEnemy;
        }
           
    }
    void Update()
    {
        if (Input.GetKey(keyCodeLeftPlayerUp))
        {
            newPosition = transform.position + (Vector3.up * speed * Time.deltaTime);
        }

        if (Input.GetKey(keyCodeLeftPlayerDown))
        {
            newPosition = transform.position - (Vector3.up * speed * Time.deltaTime);
        }

        newPosition.y = Mathf.Clamp(newPosition.y, -4.5f, 4.5f);
        transform.position = newPosition;

    }
}
