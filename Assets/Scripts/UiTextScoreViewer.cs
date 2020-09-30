using UnityEngine;
using UnityEngine.UI;

public class UiTextScoreViewer : IScoreViewer
{
    private readonly string _labelText;
    
    private Text _text;
    private int _point;
    
    public UiTextScoreViewer()
    {
        _labelText = "Ваш счёт:";
        _text = Object.FindObjectOfType<Text>();
    }
    public void ViewScore(int score)
    {
        _text.text = $"{_labelText} {score.ToString()}";
    }
}