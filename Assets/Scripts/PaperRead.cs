using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperRead : MonoBehaviour
{
    [SerializeField]
    private Text paperText;
    [SerializeField]
    private int countRead;
    // Start is called before the first frame update
    void Start()
    {
        countRead = 0;
    }

    public void PaperText(int count)
    {
        if (count == 1)
        {
            paperText.text = "Иди и прочти второй лист";
        }
        else if (count == 2)
        {
            paperText.text = "Иди и прочти третий лист";
        }
        else if (count == 3)
        {
            paperText.text = "Ну а теперь можешь открыть дверь";
        }
    }
}
