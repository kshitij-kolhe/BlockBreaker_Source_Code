using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float screenWidthinUnits = 16f;
    [SerializeField] float minX = 1.28f;
    [SerializeField] float maxX = 14.72f;

    void Start()
    {
        Cursor.visible = false;
    }

    
    void Update()
    {
        float mousePosition = Input.mousePosition.x / Screen.width * screenWidthinUnits;
        Vector2 paddlePosition = new Vector2(transform.position.x,transform.position.y);

        paddlePosition.x = Mathf.Clamp(mousePosition,minX,maxX);
        transform.position = paddlePosition;

    }
}
