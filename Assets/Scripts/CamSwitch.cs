using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamSwitch : MonoBehaviour
{

    public CinemachineVirtualCamera cam1;
    public CinemachineVirtualCamera cam2;
    public GameObject player1;
    public GameObject player2;


    // Start is called before the first frame update
    void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.V))
        {
            cam1.enabled = !cam1.enabled;
            cam2.enabled = !cam2.enabled;

        }
        if (cam2.enabled == true)
        {
            Camera.main.orthographic = true;
            player1.SetActive(false);
            player2.SetActive(true);
        }
        else
        {
            Camera.main.orthographic = false;
            player1.SetActive(true);
            player2.SetActive(false);
        }
    }
}
