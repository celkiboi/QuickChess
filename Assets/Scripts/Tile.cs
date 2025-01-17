using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool IsMovable { get; private set; }

    Sprite movableSprite;
    Sprite defaultSprite;

    private void OnMouseDown()
    {
        GameManager.Clicked(this.gameObject);
    }

    public void MarkAsMovable()
    {
        IsMovable = true;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = movableSprite;
    }

    public void SetAsNormal()
    {
        IsMovable = false;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = defaultSprite;
    }

    private void Start()
    {
        defaultSprite = this.gameObject.GetComponent<SpriteRenderer>().sprite;
        movableSprite = Resources.Load<Sprite>("SpriteImages/Movable");
    }
}
