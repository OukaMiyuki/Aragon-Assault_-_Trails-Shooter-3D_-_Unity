using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExplosionHandler : MonoBehaviour {
    [SerializeField] GameObject explosionObject;
    [SerializeField] MeshRenderer playerPlane;
    [SerializeField] GameObject BulletParticles;

    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void PlayExplosion() {
        explosionObject.SetActive(true);
        BulletParticles.SetActive(false);
        playerPlane.enabled = false;
    }
}
