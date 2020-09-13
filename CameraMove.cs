using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    
    // Update is called once per frame
    private void Update()
    {
        if (Player == true)
        {
            Vector3 p_Camera;
            p_Camera = Player.transform.position;

            p_Camera.z = -10;
            p_Camera.y += 3.5f;
            this.transform.position = p_Camera;
        }
        else if(Player == false)
        {
            this.transform.position = this.transform.position;
        }

        
    }
}