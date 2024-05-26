using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AnimationController : MonoBehaviourPunCallbacks
{
    public static AnimationController instance = null;

    //level3
    public Animator targetAnimatorlaser;
    public Animator targetAnimatorDoor;
    public Animator targetAnimatorDoor2;

    //level1
    public Animator DoorLevel1;
    public Animator Platform;

    //level2
    public Animator Laser1;
    public Animator Laser2;
    public Animator Laser3;
    public Animator Laser4;

    //Level4
    public Animator DoorLevel4;
    public Animator DoorLevel42;
    public Animator DoorLevel43;
    public Animator DoorLevel44;


    //Level 5
    public Animator DoorLevel5;
    public Animator DoorLevel52;
    public Animator DoorLevel53;

    public string boolName;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        //targetAnimator = GetComponent<Animator>();
    }

    public void Update()
    {
       
    }


    public void Animate()
    {
        photonView.RPC("AnimateMeRPC", RpcTarget.All,true);
    }

    public void Animate1()
    {
        photonView.RPC("AnimateMeRPCDoor", RpcTarget.All, true);
    }
    public void Animate2()
    {
        photonView.RPC("AnimateMeRPCDoor2", RpcTarget.All, true);
    }

    public void AnimateLevel1Door()
    {
        photonView.RPC("AnimateMeRPCDoorLevel1", RpcTarget.All, true);
    }

    public void AnimateLevel1Platform()
    {
        photonView.RPC("AnimateMeRPCDoorPlatform", RpcTarget.All, true);
    }

    public void AnimateLevel2Laser()
    {
        photonView.RPC("AnimateMeRPCLevel2Laser", RpcTarget.All, true);
    }
    public void AnimateLevel2Laser2()
    {
        photonView.RPC("AnimateMeRPCLevel2Laser2", RpcTarget.All, true);
    }
    public void AnimateLevel2Laser3()
    {
        photonView.RPC("AnimateMeRPCLevel2Laser3", RpcTarget.All, true);
    }
    public void AnimateLevel2Laser4()
    {
        photonView.RPC("AnimateMeRPCLevel2Laser4", RpcTarget.All, true);
    }

    public void AnimateLevel4Door()
    {
        photonView.RPC("AnimateMeRPCLevel4Door", RpcTarget.All, true);
    }
    public void AnimateLevel4Door2()
    {
        photonView.RPC("AnimateMeRPCLevel4Door2", RpcTarget.All, true);
    }
    public void AnimateLevel4Door3()
    {
        photonView.RPC("AnimateMeRPCLevel4Door3", RpcTarget.All, true);
    }
    public void AnimateLevel4Door4()
    {
        photonView.RPC("AnimateMeRPCLevel4Door4", RpcTarget.All, true);
    }

    public void AnimateLevel5Door1()
    {
        photonView.RPC("AnimateMeRPCLevel5Door1", RpcTarget.All, true);
    }
    public void AnimateLevel5Door2()
    {
        photonView.RPC("AnimateMeRPCLevel5Door2", RpcTarget.All, true);
    }
    public void AnimateLevel5Door3()
    {
        photonView.RPC("AnimateMeRPCLevel5Door3", RpcTarget.All, true);
    }
    // Update is called once per frame
    [PunRPC]
    public void AnimateMeRPC(bool state)
    {
        if (targetAnimatorlaser != null)
        {
            targetAnimatorlaser.SetBool(boolName, state);
        }
    }

    [PunRPC]
    public void AnimateMeRPCDoor(bool state)
    {
        if (targetAnimatorDoor != null)
        {
            targetAnimatorDoor.SetBool(boolName, state);
        }
    }

    [PunRPC]
    public void AnimateMeRPCDoor2(bool state)
    {
        if (targetAnimatorDoor2 != null)
        {
            targetAnimatorDoor2.SetBool(boolName, state);
        }
    }

    [PunRPC]
    public void AnimateMeRPCDoorLevel1(bool state)
    {
        if (DoorLevel1 != null)
        {
            DoorLevel1.SetBool(boolName, state);
        }
    }

    [PunRPC]
    public void AnimateMeRPCDoorPlatform(bool state)
    {
        if (Platform != null)
        {
            Platform.SetBool(boolName, state);
        }
    }

    [PunRPC]
    public void AnimateMeRPCLevel2Laser(bool state)
    {
        if (Laser1 != null)
        {
            Laser1.SetBool(boolName, state);
        }
    }

    [PunRPC]
    public void AnimateMeRPCLevel2Laser2(bool state)
    {
        if (Laser2 != null)
        {
            Laser2.SetBool(boolName, state);
        }
    }

    [PunRPC]
    public void AnimateMeRPCLevel2Laser3(bool state)
    {
        if (Laser3 != null)
        {
            Laser3.SetBool(boolName, state);
        }
    }

    [PunRPC]
    public void AnimateMeRPCLevel2Laser4(bool state)
    {
        if (Laser4 != null)
        {
            Laser4.SetBool(boolName, state);
        }
    }

    [PunRPC]
    public void AnimateMeRPCLevel4Door(bool state)
    {
        if (DoorLevel4 != null)
        {
            DoorLevel4.SetBool(boolName, state);
        }
    }
    [PunRPC]
    public void AnimateMeRPCLevel4Door2(bool state)
    {
        if (DoorLevel42 != null)
        {
            DoorLevel42.SetBool(boolName, state);
        }
    }
    [PunRPC]
    public void AnimateMeRPCLevel4Door3(bool state)
    {
        if (DoorLevel43 != null)
        {
            DoorLevel43.SetBool(boolName, state);
        }
    }
    [PunRPC]
    public void AnimateMeRPCLevel4Door4(bool state)
    {
        if (DoorLevel44 != null)
        {
            DoorLevel44.SetBool(boolName, state);
        }
    }

    [PunRPC]
    public void AnimateMeRPCLevel5Door1(bool state)
    {
        if (DoorLevel5 != null)
        {
            DoorLevel5.SetBool(boolName, state);
        }
    }
    [PunRPC]
    public void AnimateMeRPCLevel5Door2(bool state)
    {
        if (DoorLevel52 != null)
        {
            DoorLevel52.SetBool(boolName, state);
        }
    }
    [PunRPC]
    public void AnimateMeRPCLevel5Door3(bool state)
    {
        if (DoorLevel53 != null)
        {
            DoorLevel53.SetBool(boolName, state);
        }
    }
}
