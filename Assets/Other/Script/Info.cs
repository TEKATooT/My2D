using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(TextMeshPro))]

public class Info : MonoBehaviour
{
    private Text _infoText;

    private void Awake()
    {
        _infoText = gameObject.GetComponent<Text>();
        _infoText.DOText(_infoText.text, 10, true, ScrambleMode.All);
    }
}
