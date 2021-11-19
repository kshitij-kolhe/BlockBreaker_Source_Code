using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottomCollider : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Cursor.visible = true;
        SceneManager.LoadScene("EndScene");
    }


}
