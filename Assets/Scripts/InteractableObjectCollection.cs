using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class InteractableObjectCollection : ICollection<InteractableObject>, IEnumerator<InteractableObject>
{
    private List<InteractableObject> _interactableObjects;
    private ResourcesManager _rm;
    
    private int _index = -1;

    public InteractableObjectCollection()
    {
        _interactableObjects = new List<InteractableObject>();
        _rm = new ResourcesManager();
    }

    public InteractableObjectCollection(BonusData bonusData) : this()
    {
        foreach (var bonusInfo in bonusData.Bonuses)
        {
            var bonusType = bonusInfo.BonusType;
            foreach (var position in bonusInfo.Positions)
            {
                var bonus = _rm.CreateInteractableObject(bonusType, position);
                bonus.transform.position = position;
                _interactableObjects.Add(bonus);
            }
        }
    }

    public InteractableObject this[int index]
    {
        get => _interactableObjects[index];
        private set => _interactableObjects[index] = value;
    }

    public List<IExecutable> GetExecutableCollection() => _interactableObjects.Select(i => (IExecutable)i).ToList();
    
    public void AddOnDestroySubscribers(Action<InteractableObject>[] actions)
    {
        for (var i = 0; i < _interactableObjects.Count; i++)
        {
            var interactableObject = _interactableObjects[i];
            
            for (var j = 0; j < actions.Length; j++)
            {
                interactableObject.AddSubscriberOnDestroy(actions[j]);
            }
        }
    }
    
    private void DeleteObjectFromCollection(InteractableObject interactableObject)
    {
        interactableObject.RemoveSubscriberOnDestroy(DeleteObjectFromCollection);

        for (int i = 0; i < _interactableObjects.Count; i++)
        {
            var io = _interactableObjects[i];
            
            if (io == interactableObject)
            {
                io = null;
            }
        }
    }

    public IEnumerator<InteractableObject> GetEnumerator() => this;

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(InteractableObject item)
    {
        _interactableObjects.Add(item);
    }

    public void Clear()
    {
        _interactableObjects.Clear();
    }

    public bool Contains(InteractableObject item) =>_interactableObjects.Contains(item);

    public void CopyTo(InteractableObject[] array, int arrayIndex)
    {
        _interactableObjects.CopyTo(array, arrayIndex);
    }

    public bool Remove(InteractableObject item) => _interactableObjects.Remove(item);

    public int Count => _interactableObjects.Count;
    public bool IsReadOnly => false;
    
    public bool MoveNext()
    {
        if (_index == _interactableObjects.Count - 1)
        {
            Reset();
            return false;
        }
        
        _index++;
        return true;
    }

    public void Reset() => _index = -1;

    public InteractableObject Current => _interactableObjects[_index];

    object IEnumerator.Current => Current;

    public void Dispose()
    {
    }
}