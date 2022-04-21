using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    private bool toggle = true;

    public void ShowMesh(GameObject mesh)
    {
        mesh.SetActive(false);
        if (!toggle) {
            mesh.SetActive(true);
        } else {
            mesh.SetActive(false);
        }
        toggle = !toggle;
    }

    public void SetText(string newText) {
        Text txt = transform.Find("Text").GetComponent<Text>();
        txt.text = newText;
    }
}
