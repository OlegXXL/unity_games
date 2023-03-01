using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnergyControll : MonoBehaviour
{
    [SerializeField] Text energy_txt;
    [SerializeField] Text energyTimer_txt;


    private float energyInterval = 10.0f;  // Time in minutes to add 1 energy
    private int maxEnergy = 30;            // Maximum energy the player can have
    private int currentEnergy;          // Current energy the player has
    private float timeSinceLastEnergy;    // Time elapsed since last energy addition
    private float energyIntervalInSeconds;  // Energy interval in seconds
    private DateTime lastEnergyAdditionTime; // Last time energy was added
    private void Start()
    {
        //GameData.Energy = 35;
        currentEnergy = GameData.Energy;
        energyIntervalInSeconds = energyInterval * 60.0f;
        energy_txt.text = string.Format("{0}/{1}", currentEnergy, maxEnergy);

        string lastEnergyAdditionTimeString = PlayerPrefs.GetString("LastEnergyAdditionTime", string.Empty);

        if (!string.IsNullOrEmpty(lastEnergyAdditionTimeString))
        {
            lastEnergyAdditionTime = DateTime.Parse(lastEnergyAdditionTimeString);
            TimeSpan elapsedTime = DateTime.Now - lastEnergyAdditionTime;
            float elapsedTimeInSeconds = (float)elapsedTime.TotalSeconds;
            int energyToAdd = (int)(elapsedTimeInSeconds / energyIntervalInSeconds);
            if (energyToAdd > 0)
            {
                currentEnergy = Mathf.Min(currentEnergy + energyToAdd, maxEnergy);
                timeSinceLastEnergy = elapsedTimeInSeconds % energyIntervalInSeconds;
                lastEnergyAdditionTime = DateTime.Now;
                GameData.Energy = currentEnergy;
            }
        }
        else
        {
            lastEnergyAdditionTime = DateTime.Now;
            timeSinceLastEnergy = 0.0f;
        }
    }

    private void Update()
    {
        if (currentEnergy < maxEnergy)
        {
            timeSinceLastEnergy += Time.deltaTime;
            if (timeSinceLastEnergy >= energyIntervalInSeconds)
            {
                AddEnergy();
            }
            UpdateEnergyTimer();
        }
        else
        {
            energy_txt.text = string.Format("{0}/{1}", currentEnergy, maxEnergy);
            energyTimer_txt.text = "00:00";
        }
        PlayerPrefs.SetString("LastEnergyAdditionTime", lastEnergyAdditionTime.ToString());
    }

    private void OnApplicationPause(bool isPaused)
    {
        if (isPaused)
        {
            GameData.Energy = currentEnergy;
            PlayerPrefs.SetString("LastEnergyAdditionTime", lastEnergyAdditionTime.ToString());
        }
    }
    private void OnApplicationQuit()
    {
        GameData.Energy = currentEnergy;
        PlayerPrefs.SetString("LastEnergyAdditionTime", lastEnergyAdditionTime.ToString());
    }
    private void AddEnergy()
    {
        currentEnergy += 1;
        GameData.Energy = currentEnergy;
        timeSinceLastEnergy = 0.0f;
        lastEnergyAdditionTime = DateTime.Now;
    }

    private void UpdateEnergyTimer()
    {
        int minutes = (int)((energyIntervalInSeconds - timeSinceLastEnergy) / 60.0f);
        int seconds = (int)((energyIntervalInSeconds - timeSinceLastEnergy) % 60.0f);

        string energyTimer = string.Format("{0:00}:{1:00}", minutes, seconds);

        energy_txt.text = string.Format("{0}/{1}", currentEnergy, maxEnergy);
        energyTimer_txt.text = energyTimer;

        Debug.Log("Energy timer: " + energyTimer);
    }
}