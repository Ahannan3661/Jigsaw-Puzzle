using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private string message;
    [SerializeField] private Vector3 startScale;
    [SerializeField] private Vector3 endScale;



    public Color HighlightColor = Color.blue;

    public void OnMouseOver()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        transform.localScale = startScale * 0.95f;

        if (sprite != null ) sprite.color = HighlightColor;
    }

    public void OnMouseExit()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        transform.localScale = startScale;
        if (sprite != null) sprite.color = Color.white;
    }

    public void OnMouseDown()
    {
        transform.localScale = endScale;
    }

    public void OnMouseUp()
    {
        transform.localScale = startScale;

        if(targetObject != null )
        {
            targetObject.SendMessage(message);
        }
    }
}
