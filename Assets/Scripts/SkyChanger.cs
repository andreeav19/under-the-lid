using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyChanger : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer[] backgrounds;

    [Header("Properties")] 
    [SerializeField] private float speed;
    
    private EnvironmentGenerator environmentGenerator;
    void Start()
    {
        environmentGenerator = GetComponent<EnvironmentGenerator>();
        for (int i = 0; i < backgrounds.Length; i++)
        {
            if (i == (int)environmentGenerator.currentEnvironmentType)
                backgrounds[i].color = new Color(backgrounds[i].color.r, backgrounds[i].color.g, backgrounds[i].color.b, 1f);
            else
                backgrounds[i].color = new Color(backgrounds[i].color.r, backgrounds[i].color.g, backgrounds[i].color.b, 0f);
        }
    }


    private void BackgroundLogic()
    {
        if (!environmentGenerator)
            return;
        for (int i = 0; i < backgrounds.Length; i++)
        {
            if (i == (int)environmentGenerator.currentEnvironmentType)
                backgrounds[i].color = Color.Lerp(backgrounds[i].color, new Color(backgrounds[i].color.r, backgrounds[i].color.g, backgrounds[i].color.b, 1f), speed);
            else
                backgrounds[i].color = Color.Lerp(backgrounds[i].color, new Color(backgrounds[i].color.r, backgrounds[i].color.g, backgrounds[i].color.b, 0f), speed);
        }
    }
    
    void Update()
    {
        BackgroundLogic();
    }
}
