using Abstracts;
using Scriptables;
using UnityEngine;
using UnityEngine.UI;
using Utilities.ResourceManagement;

public class HealtShieldToolBarController : BaseController
{
    private readonly ResourcePath healtShieldToolBarPath = new ResourcePath("Prefabs/Canvas/Game/HealtShieldToolBar");
    private readonly ResourcePath playerHealthConfigPath = new ResourcePath("Configs/HealthConfig");
    private readonly ResourcePath canvasPath = new ResourcePath("Prefabs/Canvas/Canvas");
    private readonly ResourcePath playerShieldConfigPath = new ResourcePath("Configs/ShieldConfig");

    private readonly HealtShieldToolBarView healtShieldToolBarView;
    private readonly HealthConfig playerHealthConfig;
    private readonly ShieldConfig playerShieldConfig;

    private readonly string nameHealthTollBar = "HP";
    private readonly string nameShieldTollBar = "SP";

    private Slider hpToolBarSlider;
    private Slider spToolBarSlider;

    public HealtShieldToolBarController()
    {
        Canvas canvase = LoadView<Canvas>(canvasPath);
        healtShieldToolBarView = LoadView<HealtShieldToolBarView>(healtShieldToolBarPath);

        playerHealthConfig = ResourceLoader.LoadObject<HealthConfig>(playerHealthConfigPath);
        playerShieldConfig = ResourceLoader.LoadObject<ShieldConfig>(playerShieldConfigPath);

        hpToolBarSlider = healtShieldToolBarView.gameObject.transform.FindChild(nameHealthTollBar).GetComponent<Slider>();
        spToolBarSlider = healtShieldToolBarView.gameObject.transform.FindChild(nameShieldTollBar).GetComponent<Slider>();

        healtShieldToolBarView.gameObject.transform.parent = canvase.transform;
        healtShieldToolBarView.gameObject.transform.localScale = Vector3.one;
        RectTransform rect = healtShieldToolBarView.gameObject.GetComponent<RectTransform>();
        rect.anchoredPosition = Vector3.zero;
        rect.sizeDelta = Vector3.zero;

        EntryPoint.SubscribeToUpdate(UpdateHealtShieldToolBar);
    }

    private void UpdateHealtShieldToolBar()
    {
        if (hpToolBarSlider.maxValue != playerHealthConfig.MaximumHealth)
        {
            hpToolBarSlider.maxValue = playerHealthConfig.MaximumHealth;
        }

        hpToolBarSlider.value = playerHealthConfig.StartingHealth;

        if (spToolBarSlider.maxValue != playerShieldConfig.MaximumShield)
        {
            spToolBarSlider.maxValue = playerShieldConfig.MaximumShield;
        }

        spToolBarSlider.value = playerShieldConfig.NowShield;
    }

    protected override void OnDispose()
    {
        EntryPoint.UnsubscribeFromUpdate(UpdateHealtShieldToolBar);
    }
}
