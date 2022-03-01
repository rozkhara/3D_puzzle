using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtons : MonoBehaviour
{
    public void PanelExit()
    {
        StartCoroutine(PanelExitCoroutine());
    }

    private IEnumerator PanelExitCoroutine()
    {
        yield return new WaitForEndOfFrame();
        GameManager.instance.FreezeAll();
    }


}
