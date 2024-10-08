using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityController : MonoBehaviour
{
    public Renderer custRender;

    // Start is called before the first frame update
    void Start()
    {
        custRender = GetComponent<Renderer>();
        custRender.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "Batframe2_fx")
        {
            if (NaranjerosInputManager.instance.hitButtonIsPressed)
            {
                custRender.enabled = true;

            }
            else
            {
                custRender.enabled = false;
            }
        }

        if (gameObject.name == "Batframe2" || gameObject.name == "contornoframe2rojo_fx_0")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                custRender.enabled = true;
            }
            else
            {
                custRender.enabled = false;
            }
        }

        if (gameObject.name == "Bateador" || gameObject.name == "bateadorrojo_0")
        {
            if (NaranjerosInputManager.instance.hitButtonIsPressed)
            {
                custRender.enabled = false;
            }
            else
            {
                custRender.enabled = true;
            }
        }
    }
}
