using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class DamageNumber : MonoBehaviour
{
    [SerializeField] private float visibleTime;
    [SerializeField] private float fadeDuration;
    private TextMeshProUGUI textField;
    private float damageNumber;
    private float multiplier;

    void Awake()
    {
        textField = gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void VisualizeDamageNumber(float damageNumber, float multiplier)
    {
        this.damageNumber = damageNumber;
        this.multiplier = multiplier;

        ShowNumber();

        StartCoroutine(Fade());
    }

    private void ShowNumber()
    {
        textField.text = Mathf.Floor(damageNumber).ToString();

        switch (multiplier)
        {
            case < 1:
                textField.color = Color.grey;
                break;

            case > 1:
                textField.color = Color.red;
                break;

            default:
                textField.color = Color.white;
                break;
        }
    }

    private IEnumerator Fade()
    {
        yield return new WaitForSeconds(visibleTime);

        float timeElapsed = 0f;

        while (timeElapsed <= fadeDuration)
        {
            Color color = textField.color;
            color.a = Mathf.Lerp(1f, 0f, timeElapsed / fadeDuration);
            textField.color = color;

            timeElapsed += Time.deltaTime;

            yield return null;
        }

        Destroy(gameObject);
    }
}
