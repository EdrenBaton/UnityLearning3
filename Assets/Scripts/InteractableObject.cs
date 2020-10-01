using System;
using UnityEngine;

public abstract class InteractableObject : BaseGameObject, IExecutable
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

    public abstract void Execute();

    public void AddSubscriberOnDestroy(Action<InteractableObject> method)
    {
        ObjectDestroyed += method;
    }

    public void RemoveSubscriberOnDestroy(Action<InteractableObject> method)
    {
        ObjectDestroyed -= method;
    }

    private void DestroyInteractableObject()
    {
        ObjectDestroyed?.Invoke(this);
        Destroy(gameObject);
    }
}