using UnityEngine;

public class FXProjectile : FXInstance
{
    // Start is called before the first frame update
    [SerializeField]
    public Transform _target;
    private bool isCalled = false;
    [SerializeField]
    [Range(0.5f, 5.0f)]
    private float _targetRange;
    [SerializeField]
    [Range(0.5f, 25f)]
    private float _projectileSpeed;
    private const float MAX_DISTANCE = 500f;
    private GameObject spawnObject;
    private void Awake()
    {
        spawnObject = Instantiate(base.spawnFX, transform);
        spawnObject.transform.SetParent(null);
        foreach (Transform fxObj in transform.GetComponentsInChildren<Transform>(true))
        {
            if(fxObj.name != transform.name) fxObj.gameObject.SetActive(false);
        }
    }


    private void FixedUpdate()
    {
        CheckDistance();
    }

    private void CheckDistance()
    {
        if (spawnObject.GetComponent<ParticleSystem>().isPlaying) return;
        foreach (Transform fxObj in transform.GetComponentsInChildren<Transform>(true)) fxObj.gameObject.SetActive(true);
        
        transform.position += Time.deltaTime * Vector3.forward * _projectileSpeed;
        float distance = Vector3.Distance(transform.position, _target.position);
        if (distance <= _targetRange || distance >= MAX_DISTANCE)
        {
            Transform[] temp = gameObject.GetComponentsInChildren<Transform>();
            base.SpawnFX(transform);
            foreach(Transform fxChild in temp) Destroy(fxChild.gameObject);
            Destroy(spawnObject);
        }
    }
}
