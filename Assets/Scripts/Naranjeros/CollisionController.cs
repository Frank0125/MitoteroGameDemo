using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public bool isInside = false;
    public void Update()
    {
        if (NaranjerosInputManager.instance.hitButtonIsPressed && isInside)
        {
            Debug.Log("HITTTT");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInside = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInside = false;
    }
}