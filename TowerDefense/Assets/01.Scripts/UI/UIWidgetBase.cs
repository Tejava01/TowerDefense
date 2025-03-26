using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWidgetBase : MonoBehaviour
{
    public void DoShowHideWidget(bool showWidget)
    {
        this.gameObject.SetActive(showWidget);
    }
}
