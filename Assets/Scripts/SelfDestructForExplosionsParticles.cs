using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructForExplosionsParticles : MonoBehaviour {
    void Start() {
        Destroy(gameObject, 5f);
    }
}
