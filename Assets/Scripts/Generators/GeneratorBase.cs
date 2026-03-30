using UnityEngine;
using System.Collections.Generic;

public abstract class GeneratorBase<T> : Generator where T : Object
{
    protected List<T> _createdItems = new List<T>();

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        DrawItemsGizmos();
    }

    protected virtual void DrawItemsGizmos()
    {
        foreach (var item in _createdItems)
        {
            if (item != null)
            {
                DrawItemGizmo(item);
            }
        }
    }

    protected abstract void DrawItemGizmo(T item);
}