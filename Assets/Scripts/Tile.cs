using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    Sprite movableSprite;
    Sprite defaultSprite;

    private void OnMouseDown()
    {
        GameManager.Clicked(this.gameObject);
        Debug.Log("Click");
    }

    public void MarkAsMovable()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = movableSprite;
    }

    public void SetAsNormal()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = defaultSprite;
    }

    private void Start()
    {
        defaultSprite = this.gameObject.GetComponent<SpriteRenderer>().sprite;
        movableSprite = Resources.Load<Sprite>("SpriteImages/Movable");
    }
}
