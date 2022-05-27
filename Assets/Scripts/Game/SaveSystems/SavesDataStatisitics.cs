using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavesDataStatistics{

    public int highScore;
    public int totalZombiesKilled;
    public int totalZombiesKilledMedium;
    public int totalZombiesKilledHard;
    public int maxWave;
    public int highScoreWaterBombs;
    public int totalWaterBombsExploded;
    public int totalWaterBombsExplodedMedium;
    public int totalWaterBombsExplodedHard;
    public int maxWaveWaterBombs;
    public int highscoreMedium;
    public int highscoreHard;
    public int highscoreWaterBombsMedium;
    public int highscoreWaterBombsHard;
    public int maxWaveMedium;
    public int maxWaveHard;
    public int maxWaveWaterBombsMedium;
    public int maxWaveWaterBombsHard;

    public SavesDataStatistics(int _highscore, int _highscoreWaterBombs, int _totalZombiesKilled, int _totalZombiesKilledMedium, int _totalZombiesKilledHard, int _totalWaterBombsExploded,
                               int _totalWaterBombsExplodedMedium, int _totalWaterBombsExplodedHard, int _maxWave, int _maxWaveWaterBombs, int _highscoreMedium, int _highscoreHard,
                               int _highscoreWaterBombsMedium, int _highscoreWaterBombsHard, int _maxWaveMedium, int _maxWaveHard, int _maxWaveWaterBombsMedium, int _maxWaveWaterBombsHard)
    {
        highScore = _highscore;
        totalZombiesKilled = _totalZombiesKilled;
        totalZombiesKilledMedium = _totalZombiesKilledMedium;
        totalZombiesKilledHard = _totalZombiesKilledHard;
        maxWave = _maxWave;
        highScoreWaterBombs = _highscoreWaterBombs;
        totalWaterBombsExploded = _totalWaterBombsExploded;
        totalWaterBombsExplodedMedium = _totalWaterBombsExplodedMedium;
        totalWaterBombsExplodedHard = _totalWaterBombsExplodedHard;
        maxWaveWaterBombs = _maxWaveWaterBombs;
        highscoreMedium = _highscoreMedium;
        highscoreHard = _highscoreHard;
        highscoreWaterBombsMedium = _highscoreWaterBombsMedium;
        highscoreWaterBombsHard = _highscoreWaterBombsHard;
        maxWaveMedium = _maxWaveMedium;
        maxWaveHard = _maxWaveHard;
        maxWaveWaterBombsMedium = _maxWaveWaterBombsMedium;
        maxWaveWaterBombsHard = _maxWaveWaterBombsHard;
}
}
