using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Statistics : MonoBehaviour {

    public List<TMP_Text> highScoreTexts;
    public List<TMP_Text> highScoreWaterBombsTexts;
    public List<TMP_Text> totalZombieKillsTexts;
    public List<TMP_Text> totalZombieKillsMediumTexts;
    public List<TMP_Text> totalZombieKillsHardTexts;
    public List<TMP_Text> totalWaterBombsExplodedTexts;
    public List<TMP_Text> totalWaterBombsExplodedMediumTexts;
    public List<TMP_Text> totalWaterBombsExplodedHardTexts;
    public List<TMP_Text> maxWaveTexts;
    public List<TMP_Text> maxWaveWaterBombTexts;
    public List<TMP_Text> highScoreMediumTexts;
    public List<TMP_Text> highScoreHardTexts;
    public List<TMP_Text> highScoreWaterBombsMediumTexts;
    public List<TMP_Text> highScoreWaterBombsHardTexts;
    public List<TMP_Text> maxWaveMediumTexts;
    public List<TMP_Text> maxWaveHardTexts;
    public List<TMP_Text> maxWaveWaterBombsMediumTexts;
    public List<TMP_Text> maxWaveWaterBombsHardTexts;

    public TMP_Text diff;

    public int currentDiffLookingAt = 0;

    public Animator anim;

    public GameObject easy;
    public GameObject medium;
    public GameObject hard;

    public void SetScores(int highscore, int highscoreWaterBombs, int totalZombiesKilled, int totalZombiesKilledMedium, int totalZombiesKilledHard, int totalWaterBombsExploded, 
                          int totalWaterBombsExplodedMedium, int totalWaterBombsExplodedHard, int maxWave, int maxWaveWaterBombs,int highscoreMedium, int highscoreHard,
                          int highscoreWaterBombsMedium, int highscoreWaterBombsHard, int maxWaveMedium, int maxWaveHard, int maxWaveWaterBombsMedium, int maxWaveWaterBombsHard)
    {
        foreach(TMP_Text highScoreText in highScoreTexts)
        {
            highScoreText.text = highscore.ToString();
        }
        foreach(TMP_Text totalZombieKillsText in totalZombieKillsTexts)
        {
            totalZombieKillsText.text = totalZombiesKilled.ToString();
        }
        foreach (TMP_Text totalZombieKillsMediumText in totalZombieKillsMediumTexts)
        {
            totalZombieKillsMediumText.text = totalZombiesKilledMedium.ToString();
        }
        foreach (TMP_Text totalZombieKillsHardText in totalZombieKillsHardTexts)
        {
            totalZombieKillsHardText.text = totalZombiesKilledHard.ToString();
        }
        foreach(TMP_Text maxWaveText in maxWaveTexts)
        {
            maxWaveText.text = maxWave.ToString();
        }
        foreach (TMP_Text highScoreWaterBombText in highScoreWaterBombsTexts)
        {
            highScoreWaterBombText.text = highscoreWaterBombs.ToString();
        }
        foreach(TMP_Text maxWaveWaterBombText in maxWaveWaterBombTexts)
        {
            maxWaveWaterBombText.text = maxWaveWaterBombs.ToString();
        }
        foreach(TMP_Text totalWaterBombsExplodedText in totalWaterBombsExplodedTexts)
        {
            totalWaterBombsExplodedText.text = totalWaterBombsExploded.ToString();
        }
        foreach (TMP_Text totalWaterBombsExplodedMediumText in totalWaterBombsExplodedMediumTexts)
        {
            totalWaterBombsExplodedMediumText.text = totalWaterBombsExplodedMedium.ToString();
        }
        foreach (TMP_Text totalWaterBombsExplodedHardText in totalWaterBombsExplodedHardTexts)
        {
            totalWaterBombsExplodedHardText.text = totalWaterBombsExplodedHard.ToString();
        }
        foreach (TMP_Text highScoreMediumText in highScoreMediumTexts)
        {
            highScoreMediumText.text = highscoreMedium.ToString();
        }
        foreach(TMP_Text highScoreHardText in highScoreHardTexts)
        {
            highScoreHardText.text = highscoreHard.ToString();
        }
        foreach (TMP_Text highScoreWaterBombsMediumText in highScoreWaterBombsMediumTexts)
        {
            highScoreWaterBombsMediumText.text = highscoreWaterBombsMedium.ToString();
        }
        foreach (TMP_Text highScoreWaterBombsHardText in highScoreWaterBombsHardTexts)
        {
            highScoreWaterBombsHardText.text = highscoreWaterBombsHard.ToString();
        }
        foreach (TMP_Text maxWaveMediumTexts in maxWaveMediumTexts)
        {
            maxWaveMediumTexts.text = maxWaveMedium.ToString();
        }
        foreach(TMP_Text maxWaveHardTexts in maxWaveHardTexts)
        {
            maxWaveHardTexts.text = maxWaveHard.ToString();
        }
        foreach (TMP_Text maxWaveWaterBombsMediumText in maxWaveWaterBombsMediumTexts)
        {
            maxWaveWaterBombsMediumText.text = maxWaveWaterBombsMedium.ToString();
        }
        foreach (TMP_Text maxWaveWaterBombsHardText in maxWaveWaterBombsHardTexts)
        {
            maxWaveWaterBombsHardText.text = maxWaveWaterBombsHard.ToString();
        }
    }

    public void UpdateTotalZombieKills(int value)
    {
        foreach (TMP_Text totalZombieKillsText in totalZombieKillsTexts)
        {
            totalZombieKillsText.text = value + "";
        }
    }

    public void UpdateTotalZombieKillsMedium(int value)
    {
        foreach (TMP_Text totalZombieKillsMediumText in totalZombieKillsMediumTexts)
        {
            totalZombieKillsMediumText.text = value + "";
        }
    }

    public void UpdateTotalZombieKillsHard(int value)
    {
        foreach (TMP_Text totalZombieKillsHardText in totalZombieKillsHardTexts)
        {
            totalZombieKillsHardText.text = value + "";
        }
    }

    public void UpdateTotalWaterBombsExploded(int value)
    {
        foreach (TMP_Text totalWaterBombsExplodedText in totalWaterBombsExplodedTexts)
        {
            totalWaterBombsExplodedText.text = value + "";
        }
    }

    public void UpdateTotalWaterBombsExplodedMedium(int value)
    {
        foreach (TMP_Text totalWaterBombsExplodedMediumText in totalWaterBombsExplodedMediumTexts)
        {
            totalWaterBombsExplodedMediumText.text = value + "";
        }
    }

    public void UpdateTotalWaterBombsExplodedHard(int value)
    {
        foreach (TMP_Text totalWaterBombsExplodedHardText in totalWaterBombsExplodedHardTexts)
        {
            totalWaterBombsExplodedHardText.text = value + "";
        }
    }

    public void UpdateNextDiffToLookAt(int direction)
    {
        if(direction == 1)
        {
            if(currentDiffLookingAt == 0)
                currentDiffLookingAt = 2;
            else
                currentDiffLookingAt--;
        }
        else if(direction == 0)
        {
            if(currentDiffLookingAt == 2)
                currentDiffLookingAt = 0;
            else
                currentDiffLookingAt++;
        }
    }

    public void UpdateDifficultyText()
    {
        switch (currentDiffLookingAt)
        {
            case 0:

                diff.text = "Easy";

                break;
            case 1:

                diff.text = "Medium";

                break;
            case 2:

                diff.text = "Hard";

                break;
        }
    }

    public void DisableAll()
    {
        easy.SetActive(false);
        medium.SetActive(false);
        hard.SetActive(false);
    }

    public void playAnimation(string name)
    {
        anim.SetTrigger(name);
    }

    public void SetDifficultyText(int value)
    {
        currentDiffLookingAt = value;

        UpdateDifficultyText();
    }
}
