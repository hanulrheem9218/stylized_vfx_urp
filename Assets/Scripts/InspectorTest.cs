using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectorTest : MonoBehaviour
{
    //SerializeField makes it visible with the text field.
    [Header("Character Stats")]
    [SerializeField]
    private int maxHealth = 100;
    //SerializeField that shows with the slider.
    [ContextMenuItem("Choose Random DPS", "RandomizeDPS")]
    [SerializeField]
    [Range(1,5)]
    private int damagePerSecond = 3;

    [SerializeField]
    private string characterName;

    [Header("Chacter Description")]
    [SerializeField]
    [TextArea]
    private string characterDescription;

    [SerializeField]
    [Multiline]
    private string characterMultiline;

    private int currentHealth;
    [ContextMenu("TakeDamage")]
    public void TakeDamage()
    {
        currentHealth--;
    }

    private void RandomizeDPS()
    {
        damagePerSecond = UnityEngine.Random.Range(0, maxHealth);
    }

  

    void Start()
    {
        print(FXManager.Instance.transform.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
