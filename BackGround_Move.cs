using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_Move : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private GameObject Player;

    // Update is called once per frame
    private void Update()
    {
        if (Player == true)
        {
            Vector3 p_Camera;
            p_Camera = mainCamera.transform.position;
            p_Camera.x = 0;
            p_Camera.z = 0;

            this.transform.position = p_Camera;
        }
        else if (Player == false)
        {
            this.transform.position = this.transform.position;
        }
    }
}
