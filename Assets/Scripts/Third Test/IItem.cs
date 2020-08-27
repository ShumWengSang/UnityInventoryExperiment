using UnityEngine;

public interface IItem
{
    string Name { get; }

    Sprite Image { get; }

    void OnPickUp();
}