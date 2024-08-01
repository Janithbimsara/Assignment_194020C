using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Health playerHealth;
    public UnityEngine.UI.Image totalhealthBar;
    public UnityEngine.UI.Image currenthealthBar;

    void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
    void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
}
