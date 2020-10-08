using System.Collections;
using System.Collections.Generic;

public sealed class ExecutableCollection : IEnumerable, IEnumerator
{
    private IExecutable _currentObject;
    private readonly List<IExecutable> _executableObjects;
    private int _index = -1;

    public ExecutableCollection()
    {
        _executableObjects = new List<IExecutable>();
    }

    public ExecutableCollection(params List<IExecutable>[] executableObjects) : this()
    {
        foreach (var executableObject in executableObjects)
            foreach (var eo in executableObject)
                Add(eo);
    }

    public IExecutable this[int i]
    {
        get => _executableObjects[i];
        private set => _executableObjects[i] = value;
    }

    public int Count => _executableObjects.Count;

    public IEnumerator GetEnumerator()
    {
        return this;
    }

    public void Reset()
    {
        _index = -1;
    }

    public object Current => _executableObjects[_index];

    public bool MoveNext()
    {
        if (_index == _executableObjects.Count - 1)
        {
            Reset();
            return false;
        }

        _index++;
        return true;
    }

    public void Add(IExecutable executableObject)
    {
        if (executableObject is InteractableObject io) io.AddSubscriberOnDestroy(Remove);
        _executableObjects.Add(executableObject);
    }

    public void Remove(IExecutable executableObject)
    {
        _executableObjects.Remove(executableObject);
    }

    private void Remove(InteractableObject interactableObject)
    {
        _executableObjects.Remove(interactableObject);
        interactableObject.RemoveSubscriberOnDestroy(Remove);
    }

    public void ExecuteAll()
    {
        for (var i = 0; i < _executableObjects.Count; i++) _executableObjects[i]?.Execute();
    }
}