using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCamera : MonoBehaviour
{
    public Camera enemyCamera;
    void Update()
    {
        transform.LookAt(transform.position + enemyCamera.transform.rotation * Vector3.back,
                        enemyCamera.transform.rotation * Vector3.down);
    }
}
