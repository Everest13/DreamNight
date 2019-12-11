using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual float radius { get; set; }

    bool hasInteracted = false;

    public Transform interactiontransform;
    
    Transform player;

    void Start()
    {
        player = PlayerManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, interactiontransform.position);

        if (distance <= radius && !hasInteracted) //TODO: не уверена в необходимости второго условия
        {
            Interacte();
            hasInteracted = true;
        }

    }

    public virtual void Interacte()
    {
        Debug.Log(interactiontransform.name + " interracting with " + transform.name);
    }
}
