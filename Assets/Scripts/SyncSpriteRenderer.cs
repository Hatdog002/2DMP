using UnityEngine;
using Photon.Pun;

public class SyncSpriteRenderer : MonoBehaviourPun, IPunObservable
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // If this is the local player, send the data
            if (spriteRenderer.sprite != null)
            {
                stream.SendNext(spriteRenderer.sprite.name); // Send sprite name
            }
            else
            {
                stream.SendNext(""); // Send empty string if sprite is null
            }

            stream.SendNext(spriteRenderer.flipX); // Send flipX state
        }
        else
        {
            // If this is a remote player, receive the data
            string spriteName = (string)stream.ReceiveNext();
            if (!string.IsNullOrEmpty(spriteName))
            {
                Sprite newSprite = Resources.Load<Sprite>(spriteName);
                if (newSprite != null)
                {
                    spriteRenderer.sprite = newSprite;
                }
            }
            else
            {
                spriteRenderer.sprite = null;
            }

            bool flipX = (bool)stream.ReceiveNext();
            spriteRenderer.flipX = flipX;
        }
    }
}
