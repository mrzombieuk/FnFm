using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControls : MonoBehaviour
{

    public Transform MainCamera;
    public Transform CamLeft;
    public Transform CamRight;
    public Transform CamCentre;

    public GameObject LeftButton;
    public GameObject RightButton;
    public GameObject UpButton;

    public bool Left, Right = false;
    public bool Centre = true;


    // Light Controls
    public GameObject LightButton;
    public GameObject VentLight;
    public GameObject SideRoomVentLight;
    public bool ToggleSideRoomLight = false;
    public bool ToggleVentLight = false;

    public void Start()
    {
        RightButton.SetActive(true);
        LeftButton.SetActive(true);
        LightButton.SetActive(false);
        VentLight.SetActive(false);
    }

    public void LookLeft()
    {
        if (Left == false && Right == false) // Centre View
        {
            MainCamera.transform.position = CamLeft.transform.position;
            MainCamera.transform.eulerAngles = new Vector3(0,-90,0);
            Left = true;
            Centre = false;
            Right = false;
            LeftButton.SetActive(false);
            RightButton.SetActive(true);
            LightButton.SetActive(true);
        }

        if (Left == false && Right == true) // Right View
        {
            MainCamera.transform.position = CamCentre.transform.position;
            MainCamera.transform.eulerAngles = new Vector3(0, 0, 0);
            Left = false;
            Centre = true;
            Right = false;
            RightButton.SetActive(true);
            LeftButton.SetActive(true);
            LightButton.SetActive(false);
        }

    }

    public void LookRight()
    {
        if (Left == false && Right == false) // Centre View
        {
            MainCamera.transform.position = CamRight.transform.position;
            MainCamera.transform.eulerAngles = new Vector3(0, 90, 0);
            Left = false;
            Centre = false;
            Right = true;
            LeftButton.SetActive(true);
            RightButton.SetActive(false);
            LightButton.SetActive(true);
        }

        if (Left == true && Right == false) // Right View
        {
            MainCamera.transform.position = CamCentre.transform.position;
            MainCamera.transform.eulerAngles = new Vector3(0, 0, 0);
            Left = false;
            Centre = true;
            Right = false;
            RightButton.SetActive(true);
            LeftButton.SetActive(true);
            LightButton.SetActive(false);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && Right == true)
        {
            //print("Vent Light");
            ToggleVentLight = !ToggleVentLight;
        }

        if (ToggleVentLight)
            {
                VentLight.SetActive(true);
            }
        else if (!ToggleVentLight)
        {
                VentLight.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && Left == true)
        {
            //print("Vent Light");
            ToggleSideRoomLight = !ToggleSideRoomLight;
        }

        if (ToggleSideRoomLight)
        {
            SideRoomVentLight.SetActive(true);
        }
        else if (!ToggleSideRoomLight)
        {
            SideRoomVentLight.SetActive(false);
        }

    }



}
