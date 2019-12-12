using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: к удалению

public class Interactable : MonoBehaviour
{
    public virtual float radius { get; set; }

    bool hasInteracted = false;

    public Transform interactiontransform;
    
    Transform player;
    PlayerManager instance;

    void Start()
    {
        instance = PlayerManager.instance;
        player = PlayerManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(PlayerManager.instance.player.transform.position);
        Debug.Log(instance);

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
