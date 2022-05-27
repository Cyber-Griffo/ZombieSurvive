using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    private static string pathStatistics = Application.persistentDataPath + "/statistics.zombieSurvive";
    private static string pathVolume = Application.persistentDataPath + "/volume.zombieSurvive";
    private static string pathResolution = Application.persistentDataPath + "/resolution.zombieSurvive";
    private static string pathQuality = Application.persistentDataPath + "/quality.zombieSurvive";
    private static string pathFullscreen = Application.persistentDataPath + "/fullscreen.zombieSurvive";
    private static string pathMausSensitivity = Application.persistentDataPath + "/maussensitivity.zombieSurvive";
    private static string pathRenderDistance = Application.persistentDataPath + "/renderdistance.zombieSurvive";
    private static string pathDifficulty = Application.persistentDataPath + "/difficulty.zombieSurvive";
    private static string pathGameMode = Application.persistentDataPath + "/gamemode.zombieSurvive";

    public static SavesDataStatistics LoadDataStatistics()
    {
        if (File.Exists(pathStatistics))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(pathStatistics, FileMode.Open);

            SavesDataStatistics data = formatter.Deserialize(stream) as SavesDataStatistics;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("No File exists...");
            return null;
        }
    }

    public static void SaveDataStatistics(int highscore, int highscoreWaterBombs, int totalZombiesKilled, int totalZombiesKilledMedium, int totalZombiesKilledHard, int totalWaterBombsExploded,
                                          int totalWaterBombsExplodedMedium, int totalWaterBombsExplodedHard, int maxWave, int maxWaveWaterBombs, int highscoreMedium, int highscoreHard,
                                          int highscoreWaterBombsMedium, int highscoreWaterBombsHard, int maxWaveMedium, int maxWaveHard, int maxWaveWaterBombsMedium, int maxWaveWaterBombsHard)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(pathStatistics, FileMode.Create);

        SavesDataStatistics data = new SavesDataStatistics(highscore, highscoreWaterBombs, totalZombiesKilled, totalZombiesKilledMedium, totalZombiesKilledHard, totalWaterBombsExploded, totalWaterBombsExplodedMedium,
                                                           totalWaterBombsExplodedHard, maxWave, maxWaveWaterBombs, highscoreMedium, highscoreHard, highscoreWaterBombsMedium, 
                                                           highscoreWaterBombsHard, maxWaveMedium, maxWaveHard, maxWaveWaterBombsMedium, maxWaveWaterBombsHard);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveDataGameMode LoadDataGameMode()
    {
        if (File.Exists(pathGameMode))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(pathGameMode, FileMode.Open);

            SaveDataGameMode data = formatter.Deserialize(stream) as SaveDataGameMode;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("No File exists...");
            return null;
        }
    }

    public static void SaveDataGameMode(int value)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(pathGameMode, FileMode.Create);

        SaveDataGameMode data = new SaveDataGameMode(value);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SavesDataMausSensitivitySave LoadDataMausSensitivitySave()
    {
        if (File.Exists(pathMausSensitivity))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(pathMausSensitivity, FileMode.Open);

            SavesDataMausSensitivitySave data = formatter.Deserialize(stream) as SavesDataMausSensitivitySave;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("No File exists...");
            return null;
        }
    }

    public static void SaveDataMausSensitivitySave(float value)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(pathMausSensitivity, FileMode.Create);

        SavesDataMausSensitivitySave data = new SavesDataMausSensitivitySave(value);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SavesDataRenderDistanceSave LoadDataRenderDistanceSave()
    {
        if (File.Exists(pathRenderDistance))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(pathRenderDistance, FileMode.Open);

            SavesDataRenderDistanceSave data = formatter.Deserialize(stream) as SavesDataRenderDistanceSave;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("No File exists...");
            return null;
        }
    }

    public static void SaveDataRenderDistanceSave(float value)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(pathRenderDistance, FileMode.Create);

        SavesDataRenderDistanceSave data = new SavesDataRenderDistanceSave(value);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveDataDifficulty LoadDataDifficultySave()
    {
        if (File.Exists(pathDifficulty))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(pathDifficulty, FileMode.Open);

            SaveDataDifficulty data = formatter.Deserialize(stream) as SaveDataDifficulty;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("No File exists...");
            return null;
        }
    }

    public static void SaveDataDifficultySave(int value)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(pathDifficulty, FileMode.Create);

        SaveDataDifficulty data = new SaveDataDifficulty(value);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SavesDataVolumeSave LoadDataVolumeSave()
    {
        if (File.Exists(pathVolume))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(pathVolume, FileMode.Open);

            SavesDataVolumeSave data = formatter.Deserialize(stream) as SavesDataVolumeSave;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("No File exists...");
            return null;
        }
    }

    public static void SaveDataVolumeSave(float value)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(pathVolume, FileMode.Create);

        SavesDataVolumeSave data = new SavesDataVolumeSave(value);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static SavesDataResolutionSave LoadDataResolutionSave()
    {
        if (File.Exists(pathResolution))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(pathResolution, FileMode.Open);

            SavesDataResolutionSave data = formatter.Deserialize(stream) as SavesDataResolutionSave;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("No File exists...");
            return null;
        }
    }

    public static void SaveDataResolutionSave(int value)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(pathResolution, FileMode.Create);

        SavesDataResolutionSave data = new SavesDataResolutionSave(value);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static SavesDataQualitySave LoadDataQualitySave()
    {
        if (File.Exists(pathQuality))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(pathQuality, FileMode.Open);

            SavesDataQualitySave data = formatter.Deserialize(stream) as SavesDataQualitySave;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("No File exists...");
            return null;
        }
    }

    public static void SaveDataQualitySave(int value)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(pathQuality, FileMode.Create);

        SavesDataQualitySave data = new SavesDataQualitySave(value);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static SavesDataFullscreenSave LoadDataFullscreenSave()
    {
        if (File.Exists(pathFullscreen))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(pathFullscreen, FileMode.Open);

            SavesDataFullscreenSave data = formatter.Deserialize(stream) as SavesDataFullscreenSave;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("No File exists...");
            return null;
        }
    }

    public static void SaveDataFullscreenSave(bool value)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(pathFullscreen, FileMode.Create);

        SavesDataFullscreenSave data = new SavesDataFullscreenSave(value);

        formatter.Serialize(stream, data);
        stream.Close();
    }
}
