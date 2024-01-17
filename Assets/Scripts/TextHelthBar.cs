using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class TextHelthBar : MonoBehaviour
{
    private Text text;

    private void Start()
    {
       text = GetComponent<Text>();
    }

    public void Draw(float startHelth, float helth)
    {
        text.text = startHelth + "/" + helth;
    }
}
