using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionItem : MonoBehaviour
{
    public Text questionText;
    public InputField answerInput;

    public void SetQuestion(int number, string english, string korean)
    {
        if (english != "")
        {
            questionText.text = number + ". " + english + " : ";
        }
        else
        {
            questionText.text = number + ". " + korean + " : ";
        }
    }


    public void SetAnswer(string answer)
    {
        //answerInput.text = answer;
    }
}
