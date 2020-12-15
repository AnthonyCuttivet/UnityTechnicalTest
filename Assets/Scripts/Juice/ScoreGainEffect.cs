using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ScoreGainEffect : MonoBehaviour
{
    public void OnEnable()
    {
        Sequence s = DOTween.Sequence();
        s
            .Join(transform.DOMove(new Vector3(transform.position.x, transform.position.y + 20, transform.position.z), 1f)).SetEase(Ease.OutSine)
            .Join(gameObject.GetComponent<TextMeshProUGUI>().DOFade(0, 1f)).SetEase(Ease.OutSine)
            .AppendCallback(() =>
            {
                gameObject.SetActive(false);
                gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - 20, transform.position.z);
                gameObject.GetComponent<TextMeshProUGUI>().color = new Color(gameObject.GetComponent<TextMeshProUGUI>().color.r, gameObject.GetComponent<TextMeshProUGUI>().color.g,gameObject.GetComponent<TextMeshProUGUI>().color.b, 1);
            });

        s.Play();
    }
}
