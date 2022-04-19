using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image HPBar;
    float CurrentHealth;
    private float MaxHealth = 100;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        HPBar = GetComponent<Image>();
        player = FindObjectOfType<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = player.HP;
        HPBar.fillAmount = CurrentHealth / MaxHealth;

    }
}
