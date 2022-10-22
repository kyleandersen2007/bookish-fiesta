using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPBar : MonoBehaviour
{
    Slider slider;
    float timeUntilBarIsHidden = 0f;

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
    }

    public void SetHealth(float health)
    {
        slider.value = health;
        timeUntilBarIsHidden = 3f;
    }

    public void SetMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    private void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
        timeUntilBarIsHidden = timeUntilBarIsHidden - Time.deltaTime;

        if (slider != null)
        {
            if (timeUntilBarIsHidden <= 0)
            {
                timeUntilBarIsHidden = 0;
                slider.gameObject.SetActive(false);
            }
            else
            {
                if (!slider.gameObject.activeInHierarchy)
                {
                    slider.gameObject.SetActive(true);
                }
            }

            if (slider.value <= 0)
            {
                Destroy(slider.gameObject);
            }
        }
    }
}