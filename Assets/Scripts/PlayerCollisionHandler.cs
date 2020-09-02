using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        ifPlayerColliding();
    }

    private void ifPlayerColliding() {
        SendMessage("StopMovementOnDeath");
        SendMessage("PlayExplosion");
        SendMessage("nextScene");
    }
}
