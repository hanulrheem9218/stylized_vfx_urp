using System.Net.NetworkInformation;
using UnityEngine;

public class FXInstance : MonoBehaviour
{
    [Header("--FX Instances--")]
    [SerializeField]
    protected GameObject spawnFX;
    [SerializeField]
    protected GameObject projectileFX;
    [SerializeField]
    protected GameObject hitFX;

    private GameObject fxObject;
    public virtual void SpawnFX(in Transform originalPos)
    {
        fxObject = Instantiate(hitFX, originalPos);
        fxObject.transform.parent.DetachChildren();
    }

}
