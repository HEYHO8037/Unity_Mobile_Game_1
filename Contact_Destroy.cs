using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contact_Destroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
