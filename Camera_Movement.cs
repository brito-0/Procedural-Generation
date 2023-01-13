using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{

    // add a second camera cunt
    // https://docs.unity3d.com/Manual/MultipleCameras.html

    public Camera roomCamera;
    public Camera BossRoomCamera;
    public bool isBossRoom;

    //private Transform camera;
    private Transform loc;
    public Vector3 trackingOffset; //= new Vector3(0, 0, 0);
    private Vector3 offset;

    private void Awake()
    {
        //camera = GameObject.FindGameObjectWithTag("MainCamera").transform;

        //roomCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() as Camera;
        //BossRoomCamera = GameObject.FindGameObjectWithTag("BossCamera").GetComponent<Camera>() as Camera;
        roomCamera = GameObject.Find("Main Camera").GetComponent<Camera>() as Camera;
        BossRoomCamera = GameObject.Find("Boss Camera").GetComponent<Camera>() as Camera;

        BossRoomCamera.enabled = false;
        DisableChildren(BossRoomCamera);
        roomCamera.enabled = true;
        EnableChildren(roomCamera);

        loc = gameObject.transform;
        offset = trackingOffset;
        //offset.z = camera.position.z - loc.position.z;
        offset.z = roomCamera.transform.position.z - loc.position.z;
    }

    void MoveC(Transform loc)
    {
        if (isBossRoom)
        {
            roomCamera.enabled = false;
            DisableChildren(roomCamera);
            BossRoomCamera.enabled = true;
            EnableChildren(BossRoomCamera);
            BossRoomCamera.transform.position = (loc.position + offset);
        }
        else
        {
            //camera.position = loc.position + offset;
            BossRoomCamera.enabled = false;
            DisableChildren(BossRoomCamera);
            roomCamera.enabled = true;
            EnableChildren(roomCamera);
            roomCamera.transform.position = loc.position + offset;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MoveC(loc);
        }
    }

    private void DisableChildren(Camera camera) 
    {
        for (int i = 0; i < camera.transform.childCount; i++) 
        {
            camera.transform.GetChild(i).gameObject.SetActive(false);
            camera.transform.gameObject.tag = "BossCamera";
        }
    }

    private void EnableChildren(Camera camera) 
    {
        for (int i = 0; i < camera.transform.childCount; i++)
        {
            camera.transform.GetChild(i).gameObject.SetActive(true);
            camera.transform.gameObject.tag = "MainCamera";
        }
    }
}
