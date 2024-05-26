using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class PickUp : MonoBehaviourPunCallbacks
{
   
    public TextMeshProUGUI txtInteract;

    public GameManager SceneAt;



    //Level3
    public GameObject KeyObject;
    public bool Key;
    public bool Door;

    public bool P1isClose;
    public bool P2isClose;
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (Key)
        {
            if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<PhotonView>().IsMine)
            {
                Debug.Log("Local player entered trigger zone");
                txtInteract.text = "Press [E] to interact";
            }
        }
        if (SceneAt.LevelAt == 1)
        {
            if (Door && GameManager.instance.iskeyFoundLevel1 == true)
            {
                if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<PhotonView>().IsMine)
                {
                    Debug.Log("Local player entered trigger zone");
                    txtInteract.text = "Press [E] to interact";
                }
            }
        }
        if (SceneAt.LevelAt == 2)
        {
            if (Door && GameManager.instance.iskeyFoundLevel2 == true)
            {
                if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<PhotonView>().IsMine)
                {
                    Debug.Log("Local player entered trigger zone");
                    txtInteract.text = "Press [E] to interact";
                }
            }
        }

        if (SceneAt.LevelAt == 3)
        {
            if (Door && GameManager.instance.iskeyFound == true)
            {
                if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<PhotonView>().IsMine)
                {
                    Debug.Log("Local player entered trigger zone");
                    txtInteract.text = "Press [E] to interact";
                }
            }
        }

        if (SceneAt.LevelAt == 4)
        {
            if (Door && GameManager.instance.iskeyFoundLevel4 == true)
            {
                if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<PhotonView>().IsMine)
                {
                    Debug.Log("Local player entered trigger zone");
                    txtInteract.text = "Press [E] to interact";
                }
            }
        }

        if (SceneAt.LevelAt == 5)
        {
            if (Door && GameManager.instance.iskeyFoundLevel5 == true)
            {
                if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<PhotonView>().IsMine)
                {
                    Debug.Log("Local player entered trigger zone");
                    txtInteract.text = "Press [E] to interact";
                }
            }
        }





    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (SceneAt.LevelAt == 1)
        {
            if (Key)
            {
                if (other.gameObject.CompareTag("Player"))
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        photonView.RPC("toDestroyLevel1", RpcTarget.All);
                    }
                }
            }

            if (Door)
            {
                PlayerType type = other.GetComponent<PlayerTag>().playerType;

                if (other.gameObject.CompareTag("Player") && GameManager.instance.iskeyFoundLevel1 == true && type == PlayerType.IT)
                {
                    P1isClose = true;
                }

                if (other.gameObject.CompareTag("Player") && GameManager.instance.iskeyFoundLevel1 == true && type == PlayerType.Normal)
                {
                    P2isClose = true;
                }

                if (other.gameObject.CompareTag("Player") && P1isClose == true && P2isClose == true && Door == true && GameManager.instance.iskeyFoundLevel1)
                {
                    photonView.RPC("Level2", RpcTarget.AllBufferedViaServer);
                }
            }
        }

        if (SceneAt.LevelAt == 2)
        {
            if (Key)
            {
                if (other.gameObject.CompareTag("Player"))
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        photonView.RPC("toDestroyLevel2", RpcTarget.All);
                    }
                }
            }

            if (Door)
            {
                PlayerType type = other.GetComponent<PlayerTag>().playerType;

                if (other.gameObject.CompareTag("Player") && GameManager.instance.iskeyFoundLevel2 == true && type == PlayerType.IT)
                {
                    P1isClose = true;
                }

                if (other.gameObject.CompareTag("Player") && GameManager.instance.iskeyFoundLevel2 == true && type == PlayerType.Normal)
                {
                    P2isClose = true;
                }

                if (other.gameObject.CompareTag("Player") && P1isClose == true && P2isClose == true && Door == true && GameManager.instance.iskeyFoundLevel2)
                {
                    photonView.RPC("Level3", RpcTarget.All);
                }
            }
        }
        if (SceneAt.LevelAt == 3)
        {
            if (Key)
            {
                if (other.gameObject.CompareTag("Player"))
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        photonView.RPC("toDestroy", RpcTarget.All);
                    }
                }
            }

            if (Door)
            {
                PlayerType type = other.GetComponent<PlayerTag>().playerType;

                if (other.gameObject.CompareTag("Player") && GameManager.instance.iskeyFound == true && type == PlayerType.IT)
                {
                    P1isClose = true;
                }

                if (other.gameObject.CompareTag("Player") && GameManager.instance.iskeyFound == true && type == PlayerType.Normal)
                {
                    P2isClose = true;
                }

                if (other.gameObject.CompareTag("Player") && P1isClose == true && P2isClose == true && Door == true && GameManager.instance.iskeyFound)
                {
                    photonView.RPC("Level4", RpcTarget.All);
                }
            }
        }
        if (SceneAt.LevelAt == 4)
        {
            if (Key)
            {
                if (other.gameObject.CompareTag("Player"))
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        photonView.RPC("toDestroyLevel3", RpcTarget.All);
                    }
                }
            }

            if (Door)
            {
                PlayerType type = other.GetComponent<PlayerTag>().playerType;

                if (other.gameObject.CompareTag("Player") && GameManager.instance.iskeyFoundLevel4 == true && type == PlayerType.IT)
                {
                    P1isClose = true;
                }

                if (other.gameObject.CompareTag("Player") && GameManager.instance.iskeyFoundLevel4 == true && type == PlayerType.Normal)
                {
                    P2isClose = true;
                }

                if (other.gameObject.CompareTag("Player") && P1isClose == true && P2isClose == true && Door == true && GameManager.instance.iskeyFoundLevel4)
                {
                    photonView.RPC("Level5", RpcTarget.All);
                }
            }
        }
        if (SceneAt.LevelAt == 5)
        {
            if (Key)
            {
                if (other.gameObject.CompareTag("Player"))
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        photonView.RPC("toDestroyLevel4", RpcTarget.All);
                    }
                }
            }

            if (Door)
            {
                PlayerType type = other.GetComponent<PlayerTag>().playerType;

                if (other.gameObject.CompareTag("Player") && GameManager.instance.iskeyFoundLevel5 == true && type == PlayerType.IT)
                {
                    P1isClose = true;
                }

                if (other.gameObject.CompareTag("Player") && GameManager.instance.iskeyFoundLevel5 == true && type == PlayerType.Normal)
                {
                    P2isClose = true;
                }

                if (other.gameObject.CompareTag("Player") && P1isClose == true && P2isClose == true && Door == true && GameManager.instance.iskeyFoundLevel5)
                {
                    photonView.RPC("LevelWin", RpcTarget.All);
                }
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        PlayerType type = collision.GetComponent<PlayerTag>().playerType;
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<PhotonView>().IsMine)
        {
            Debug.Log("Local player entered trigger zone");
            txtInteract.text = "";
        }

        
            if (collision.gameObject.CompareTag("Player") && GameManager.instance.iskeyFound == true && type == PlayerType.IT)
            {
                P1isClose = false;
            }

            if (collision.gameObject.CompareTag("Player") && GameManager.instance.iskeyFound == true && type == PlayerType.Normal)
            {
                P2isClose = false;
            }
        
    }

    public void Update()
    {
       
    }

    [PunRPC]
    void Level2()
    {
        StartCoroutine(NextScene2());
    }

    [PunRPC]
    void Level3()
    {
        StartCoroutine(NextScene3());
    }
    [PunRPC]
    void Level4()
    {
        StartCoroutine(NextScene4());
    }
    [PunRPC]
    void Level5()
    {
        StartCoroutine(NextScene5());
    }
    [PunRPC]
    void LevelWin()
    {
        StartCoroutine(NextSceneWin());
    }


    private IEnumerator NextScene2()
    {
        yield return new WaitForSeconds(2f);
        PhotonNetwork.LoadLevel("2DPlatformLevel2");
        PlayerPrefs.SetInt("LevelAt",2);
        PlayerPrefs.Save();
    }
    private IEnumerator NextScene3()
    {
        yield return new WaitForSeconds(2f);
        PhotonNetwork.LoadLevel("2DPlatformLevel3");
        PlayerPrefs.SetInt("LevelAt",3);
        PlayerPrefs.Save();
    }
    private IEnumerator NextScene4()
    {
        yield return new WaitForSeconds(2f);
        PhotonNetwork.LoadLevel("2DPlatformLevel4");
        PlayerPrefs.SetInt("LevelAt",4);
        PlayerPrefs.Save();
    }
    private IEnumerator NextScene5()
    {
        yield return new WaitForSeconds(2f);
        PhotonNetwork.LoadLevel("2DPlatformLevel5");
        PlayerPrefs.SetInt("LevelAt",5);
        PlayerPrefs.Save();
    }

    private IEnumerator NextSceneWin()
    {
        yield return new WaitForSeconds(2f);
        PhotonNetwork.LoadLevel("2DPlatformLevel6");
    }

    


    [PunRPC]
    private void toDestroy()
    {
        GameManager.instance.iskeyFound = true;
        txtInteract.text = "";
        StartCoroutine(Destroy());
    }

    [PunRPC]
    private void toDestroyLevel1()
    {
        GameManager.instance.iskeyFoundLevel1 = true;
        txtInteract.text = "";
        StartCoroutine(Destroy());
    }

    [PunRPC]
    private void toDestroyLevel2()
    {
        GameManager.instance.iskeyFoundLevel2 = true;
        txtInteract.text = "";
        StartCoroutine(Destroy());
    }

    [PunRPC]
    private void toDestroyLevel3()
    {
        GameManager.instance.iskeyFoundLevel4 = true;
        txtInteract.text = "";
        StartCoroutine(Destroy());
    }
    [PunRPC]
    private void toDestroyLevel4()
    {
        GameManager.instance.iskeyFoundLevel5 = true;
        txtInteract.text = "";
        StartCoroutine(Destroy());
    }
    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1f);
        KeyObject.gameObject.SetActive(false);
    }
}