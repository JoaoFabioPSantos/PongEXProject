using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPlayerPaddle : MonoBehaviour
{
    public float speed = 5.0f;

    [Header("RightControls")]
    public KeyCode keyCodeRightPlayerUp = KeyCode.UpArrow;
    public KeyCode keyCodeRightPlayerDown = KeyCode.DownArrow;

    public bool isPlayer = false;
    public Vector3 newPosition = new Vector3(7f, 0f, 0f);
    public SpriteRenderer spriteRenderer;

    private void Start()
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
        if (Input.GetKey(keyCodeRightPlayerUp))
        {
            newPosition = transform.position + (Vector3.up * speed * Time.deltaTime);
        }

        if (Input.GetKey(keyCodeRightPlayerDown))
        {
            newPosition = transform.position - (Vector3.up * speed * Time.deltaTime);
        }

        newPosition.y = Mathf.Clamp(newPosition.y, -4.5f, 4.5f);
        transform.position = newPosition;

    }
}
