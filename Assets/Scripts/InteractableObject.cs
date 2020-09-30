using System;
using UnityEngine;

public abstract class InteractableObject : MyGameObject, IActable
{
    private event Action<InteractableObject> ObjectDestroyed;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        Interact();
        DestroyInteractableObject();
    }

    protected abstract void Interact();

    public abstract void Act();

    public void AddSubscriber(Action<InteractableObject> method)
    {
        ObjectDestroyed += method;
    }

    public void RemoveSubscriber(Action<InteractableObject> method)
    {
        ObjectDestroyed -= method;
    }

    private void DestroyInteractableObject()
    {
        ObjectDestroyed?.Invoke(this);
        Destroy(gameObject);
    }
}