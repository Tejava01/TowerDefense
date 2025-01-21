using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWidgetStageReturn : UIWidgetBase
{
    public void OnClikStageExit()
    {
        ManagerScene.Instance.DoLoadTitleScene(null);
    }
}
