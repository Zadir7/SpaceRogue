using Abstracts;
using Scriptables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.ResourceManagement;

public class HealtShieldToolBarController : BaseController
{
    private readonly ResourcePath healtShieldToolBarPath = new ResourcePath ("Prefabs/Canvas/Game/HealtShieldToolBar");
    private readonly ResourcePath playerHealthConfigPath = new ResourcePath("Assets/Scripts/Scriptables/HealthConfig");
    private readonly ResourcePath canvasPath = new ResourcePath("Prefabs/Canvas/Canvas");
    private readonly HealtShieldToolBarView healtShieldToolBarView;
    private readonly HealthConfig playerHealthConfig;

    public HealtShieldToolBarController()
    {
        Canvas canvase = LoadView<Canvas>(canvasPath);
        playerHealthConfig = ResourceLoader.LoadObject<HealthConfig>(playerHealthConfigPath);
        healtShieldToolBarView = LoadView<HealtShieldToolBarView>(healtShieldToolBarPath);

        healtShieldToolBarView.gameObject.transform.parent = canvase.transform;
        healtShieldToolBarView.gameObject.transform.localScale = Vector3.one;
        RectTransform rect = healtShieldToolBarView.gameObject.GetComponent<RectTransform>();
        rect.anchoredPosition = Vector3.zero;
        rect.sizeDelta = Vector3.zero;

        EntryPoint.SubscribeToUpdate(UpdateHealtShieldToolBar);
    }

    private void UpdateHealtShieldToolBar()
    {
        
    }
}
