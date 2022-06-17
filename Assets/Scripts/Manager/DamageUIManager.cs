using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// クラス説明
/// </summary>
public class DamageUIManager : MonoBehaviour
{
    Text _damageText;
    //　フェードアウトするスピード
    private float fadeOutSpeed = 0.5f;
    //　移動値
    [SerializeField]
    private float moveSpeed = 0.4f;

    void Start()
    {
        _damageText = GetComponentInChildren<Text>();
    }

    public void DamageText(Transform tf, int damage)
    {
        _damageText.text = $"{damage}";

        transform.position = new Vector3(tf.position.x, tf.position.y + 2, tf.position.z);
        if(damage < 5)
        {
            _damageText.color = new Color(255, 255, 255);
        }
        else if(damage < 10)
        {
            _damageText.color = new Color(255, 150, 120);
        }
        else
        {
            _damageText.color = new Color(150, 0, 30);
        }
        StartCoroutine(Time());
    }

    IEnumerator Time()
    {
        yield return new WaitForSeconds(fadeOutSpeed);
        _damageText.text = $"";
    }
    
}
