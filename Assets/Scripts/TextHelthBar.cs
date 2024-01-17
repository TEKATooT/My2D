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

    public void Draw(float helth)
    {
        text.text = "100/" + helth;
    }
}
