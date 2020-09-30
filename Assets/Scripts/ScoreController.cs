using System;

public class ScoreController
{
    private readonly IScoreViewer _scoreViewer;
    
    private int _score;

    private ScoreController()
    {
        _score = 0;
    }

    public ScoreController(IScoreViewer scoreViewer) : this()
    {
        _scoreViewer = scoreViewer;
        _scoreViewer.ViewScore(_score);
    }

    public void UpdateScore(InteractableObject interactableObject)
    {
        if (interactableObject is IBonus bonus)
        {
            var absBonus = bonus.Bonus;
            
            if (interactableObject is NegativeBonus)
            {
                absBonus *= -1;
            }

            _score += absBonus;
            
            _scoreViewer.ViewScore(_score);
        }
    }
}