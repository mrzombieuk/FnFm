using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorControl : MonoBehaviour
{
    public GameObject Door;
    public bool IsOpen;
    public bool Opening = false;

    public AudioSource audioSource;
    public AudioClip audioClipDoorClose;
    public AudioClip audioClipDoorOpen;
    public AudioClip audioClipDoorScreech;

     void Start()
    {
        IsOpen = true;
        //audioSource.clip = audioClip;
                       
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(DoorMovement());
        }
    }

    IEnumerator DoorMovement()
    {
        if (!IsOpen && Opening == false) // open door
        {
            //print("Opening");
            Opening = true;
            PlayDoorScreech();
            for (int i = 0; i < 24 ; i++)
            {
                Door.transform.position = new Vector3(Door.transform.position.x, Door.transform.position.y + 1f, Door.transform.position.z);
                yield return new WaitForSeconds(0.01f);

            }

            Opening = false;
            IsOpen = true;
        }
        else if (IsOpen && Opening == false) // close door
        {
            //print("Closing");
            PlayDoorScreech();
            Opening = true; for (int i = 0; i < 24; i++)
            {
                Door.transform.position = new Vector3(Door.transform.position.x, Door.transform.position.y - 1f, Door.transform.position.z);
                yield return new WaitForSeconds(0.01f);
                
            }

            PlayDoorClose();
            Opening = false;
            IsOpen = false;
        }
    }

    public void SetSoundSource(AudioClip clip)
    {
        audioSource.clip = clip;
    }

    public void PlayDoorClose()
    {
        SetSoundSource(audioClipDoorClose);
        audioSource.Play();
    }

    public void PlayDoorOpen()
    {
        SetSoundSource(audioClipDoorOpen);
        audioSource.Play();
    }

    public void PlayDoorScreech()
    {
        SetSoundSource(audioClipDoorScreech);
        audioSource.Play();
    }

}
