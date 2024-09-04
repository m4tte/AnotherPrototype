using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flash : MonoBehaviour
{
    public Image flash;

    public void Flashing()
    {
        flash.color = new Color(1, 1, 1, .5f);
        StartCoroutine("EndFlash");
    }

    IEnumerator EndFlash()
    {
        yield return new WaitForSeconds(.2f);
        flash.color = new Color(1, 1, 1, 0f);
    }
}
