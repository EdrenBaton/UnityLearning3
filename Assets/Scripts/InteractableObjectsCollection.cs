using System;
using System.Collections;
using Object = UnityEngine.Object;

public sealed class InteractableObjectsCollection : IEnumerable, IEnumerator
{
    private InteractableObject[] _interactableObjects;
    private int _index = -1;
    private InteractableObject _currentObject;

    public InteractableObjectsCollection()
    {
        var interactableObjects = Object.FindObjectsOfType<InteractableObject>();
        _interactableObjects = new InteractableObject[0];
        
        for (var i = 0; i < interactableObjects.Length; i++)
        {
            var interactableObject = interactableObjects[i];
            Add(interactableObject);
            interactableObject.AddSubscriberOnDestroy(DeleteObjectFromCollection);
        }
    }

    public InteractableObject this [int i]
    {
        get => _interactableObjects[i];
        private set => _interactableObjects[i] = value;
    }

    public void Add(InteractableObject interactiveObject)
    {
        Array.Resize(ref _interactableObjects, Length + 1);
        _interactableObjects[Length - 1] = interactiveObject;
    }

    public void AddOnDestroySubscribers(Action<InteractableObject>[] actions)
    {
        for (var i = 0; i < _interactableObjects.Length; i++)
        {
            var interactableObject = _interactableObjects[i];
            
            for (int j = 0; j < actions.Length; j++)
            {
                interactableObject.AddSubscriberOnDestroy(actions[j]);
            }
        }
    }
    
    private void DeleteObjectFromCollection(InteractableObject interactableObject)
    {
        interactableObject.RemoveSubscriberOnDestroy(DeleteObjectFromCollection);

        for (int i = 0; i < _interactableObjects.Length; i++)
        {
            var io = _interactableObjects[i];
            
            if (io == interactableObject)
            {
                io = null;
            }
        }
    }

    public void ExecuteAll()
    {
        for (int i = 0; i < _interactableObjects.Length; i++)
        {
            var interactableObject = _interactableObjects[i];
            
            if (interactableObject != null)
            {
                interactableObject.Execute();
            }
        }
    }

    public int Length => _interactableObjects.Length;

    public void Reset() => _index = -1;

    public IEnumerator GetEnumerator() => this;

    public object Current => _interactableObjects[_index];

    public bool MoveNext()
    {
        if (_index == _interactableObjects.Length - 1)
        {
            Reset();
            return false;
        }
        
        _index++;
        return true;
    }
}