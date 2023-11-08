using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXHit : MonoBehaviour
{
    void Update()
    {
        if (!gameObject.GetComponent<ParticleSystem>().isPlaying) Destroy(this.gameObject);
    }
}
