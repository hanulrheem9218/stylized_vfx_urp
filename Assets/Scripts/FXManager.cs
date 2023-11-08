using System;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
public class FXManager : MonoBehaviour
{
    #region Variables
    internal static FXManager instance = null;
    public static FXManager Instance { get; private set; }
    [SerializeField]
    private List<GameObject> _fxInstances;
    [SerializeField]
    private Transform _target;
    private Transform _spawnPos;
    private int _fxIndex = 0;
    private int camIndex = -1;
    private Camera _currentCam;
    private List<System.Tuple<Vector3,Quaternion>> _camPositions;
    private bool _isInstanceCalled = false;
    #endregion

    #region Unity Functions
    private void Awake()
    {
        _camPositions = new List<System.Tuple<Vector3, Quaternion>>();
        _camPositions.Add(new Tuple<Vector3,Quaternion>(new Vector3(-9.02000046f, 10f, -6.53999996f),new Quaternion(0.351077318f, 0.424271405f, -0.182892025f, 0.814425647f)));
        _camPositions.Add(new Tuple<Vector3, Quaternion>(new Vector3(-9.02000046f, 10f, 11.54f), new Quaternion(0.19319281f, 0.801524937f, -0.345515907f, 0.44816649f)));
        _camPositions.Add(new Tuple<Vector3, Quaternion>(new Vector3(6f, 12.8999996f, 13.6999998f), new Quaternion(-0.157683879f, 0.845511675f, -0.401585549f, -0.314602882f)));
        _camPositions.Add(new Tuple<Vector3, Quaternion>(new Vector3(6.57000017f, 1.77999997f, 12.4099998f),new Quaternion(0.086688973f, 0.959233284f, -0.0148792826f, -0.2685799f)));
        GetInstance();
    }
    void Start()
    {
        _spawnPos = GameObject.FindGameObjectWithTag("Respawn").transform;
        _currentCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    void Update()
    {
        HandleKeybinds();
    }
    #endregion

    #region Functions 
    private void GetInstance()
    {
        if (Instance != null && Instance != this) Destroy(this.gameObject);
        else Instance = this;
    }
    private void ShootProjectile(in int index)
    {
       FXProjectile projectile =  Instantiate(_fxInstances[index], _spawnPos).GetComponent<FXProjectile>();
        projectile._target = _target;
    }
    private void HandleKeybinds()
    {
        if (!_isInstanceCalled && _camPositions.Count != 0 && camIndex != -1)
        {
            this._currentCam.GetComponent<Transform>().transform.SetLocalPositionAndRotation(_camPositions[camIndex].Item1, _camPositions[camIndex].Item2);
            _isInstanceCalled = true;
        }

        if(camIndex >= 3) camIndex = -1;
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log($"Cam Switched to Pos {++camIndex}");
            _isInstanceCalled = false;
        }

        if (_fxIndex >= _fxInstances.Count) _fxIndex = -1;
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log($"Vfx Object Swtiched to {++_fxIndex}");
        }

        if (Input.GetKeyDown(KeyCode.Space) && _fxIndex != -1) ShootProjectile(in _fxIndex);
    }

    #endregion
}
#endif
