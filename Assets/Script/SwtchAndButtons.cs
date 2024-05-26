using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
public class SwtchAndButtons : MonoBehaviourPunCallbacks
{
    //public AnimationController controller;
    public TextMeshProUGUI txtInteract;
    PlayerType type;

    public GameManager SceneAt;
    //Level 1
    public bool DoorLevel1;
    public bool Platform;
    public bool Platform1;

    //Level 2
    public bool Laser1;
    public bool Laser2;
    public bool Laser3;
    
    //Level 3
    public bool LaserOpen;
    public bool DoorOpen;
    public bool DoorOpen2;

    //Level 4
    public bool Level4Door;
    public bool Level4Door2;
    public bool Level4Door3;
    public bool Level4Door4;

    //Level 5 
    public bool Level5Door;
    public bool Level5Door2;
    public bool Level5Door3;
    public void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<PhotonView>().IsMine)
        {
            Debug.Log("Local player entered trigger zone");
            txtInteract.text = "Press [E] to interact";
        }
        else if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<PhotonView>().IsMine && Platform || Platform1)
        {
            Debug.Log("Local player entered trigger zone");
            txtInteract.text = "Somethings Happening";
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(SceneAt.LevelAt ==1)
        {
            PlayerType type = other.GetComponent<PlayerTag>().playerType;
            if (other.gameObject.CompareTag("Player"))
            {
                if (DoorLevel1)
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        Debug.Log("Player pressed [E]");
                        AnimationController.instance.AnimateLevel1Door();
                    }
                }
            }
            if (other.gameObject.CompareTag("Player") && type == PlayerType.IT)
            {
                if (Platform)
                {
                    SceneAt.platformStep = true;
                }
            }
            if (other.gameObject.CompareTag("Player") && type == PlayerType.Normal)
            {
                if (Platform1)
                {
                    SceneAt.platformStep1 = true;
                }
            }

            if (SceneAt.platformStep1 && SceneAt.platformStep)
            {
                AnimationController.instance.AnimateLevel1Platform();
            }
        }

        if (SceneAt.LevelAt ==2)
        {
            PlayerType type = other.GetComponent<PlayerTag>().playerType;
            if (other.gameObject.CompareTag("Player"))
            {
                if (Laser1)
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        Debug.Log("Player pressed [E]");
                        AnimationController.instance.AnimateLevel2Laser();
                    }
                }

                if (Laser2)
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        Debug.Log("Player pressed [E]");
                        AnimationController.instance.AnimateLevel2Laser2();
                    }
                }

                if (Laser3)
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        Debug.Log("Player pressed [E]");
                        AnimationController.instance.AnimateLevel2Laser3();
                        AnimationController.instance.AnimateLevel2Laser4();
                    }
                }

            }
        }

        if(SceneAt.LevelAt == 3)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Player is in trigger zone");
                if (LaserOpen)
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        Debug.Log("Player pressed [E]");
                        AnimationController.instance.Animate();
                    }
                }

                if (DoorOpen)
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        Debug.Log("Player pressed [E]");
                        AnimationController.instance.Animate1();
                    }
                }

                if (DoorOpen2)
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        Debug.Log("Player pressed [E]");
                        AnimationController.instance.Animate2();
                    }
                }

            }
        }

        if(SceneAt.LevelAt == 4)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Player is in trigger zone");
                if (Level4Door)
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        Debug.Log("Player pressed [E]");
                        AnimationController.instance.AnimateLevel4Door();
                    }
                }
                if (Level4Door2)
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        Debug.Log("Player pressed [E]");
                        AnimationController.instance.AnimateLevel4Door2();
                    }
                }
                if (Level4Door3)
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        Debug.Log("Player pressed [E]");
                        AnimationController.instance.AnimateLevel4Door3();
                    }
                }
                if (Level4Door4)
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        Debug.Log("Player pressed [E]");
                        AnimationController.instance.AnimateLevel4Door4();
                    }
                }
            }
        }

        if (SceneAt.LevelAt == 5)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Player is in trigger zone");
                if (Level5Door)
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        Debug.Log("Player pressed [E]");
                        AnimationController.instance.AnimateLevel5Door1();
                    }
                }
                if (Level5Door2)
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        Debug.Log("Player pressed [E]");
                        AnimationController.instance.AnimateLevel5Door2();
                    }
                }
                if (Level5Door3)
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        Debug.Log("Player pressed [E]");
                        AnimationController.instance.AnimateLevel5Door3();
                    }
                }
              
            }
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<PhotonView>().IsMine)
        {
            Debug.Log("Local player entered trigger zone");
            txtInteract.text = "";
        }

        if (SceneAt.LevelAt == 1)
        {
            if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<PhotonView>().IsMine)
            {
                SceneAt.platformStep = false;
                SceneAt.platformStep1 = false;
            }    
        }
    }

    

}
