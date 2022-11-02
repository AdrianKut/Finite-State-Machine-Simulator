using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class WaterStateManager : MonoBehaviour
{
    public WaterFillingState FillingState = new WaterFillingState();
    public WaterFullState FullState = new WaterFullState();
    public WaterSpoilageState SpoillingState = new WaterSpoilageState();
    public WaterPouringOutState PouringOutState = new WaterPouringOutState();
    private WaterBaseState state;

    [Header("Main Settings")]
    public List<GameObject> waterList = new List<GameObject>();
    public float Timer;
    public bool IsAutomatic = false;
    private bool isStarted = false;
    public UI UI;

    [Header("Filling State")]
    [SerializeField] private GameObject waterPrefab;
    [SerializeField] private Transform spawnPoint;

    private void Start()
    {
        UI = GetComponent<UI>();
    }

    private void Update()
    {
        if (isStarted)
            state.UpdateState(this);

        UpdateTimer();
    }

    private void UpdateTimer()
    {
        if (Timer > 0f)
        {
            Timer -= Time.deltaTime;
            UI.TextStateDuration.text = $"{Timer:F2}s";
        }
    }

    public void StartAutomaticSimulation()
    {
        UI.ToggleAutomatic.isOn = true;
        UI.ButtonAutomatic.interactable = false;
        UI.ButtonFilling.interactable = false;
        UI.ButtonPouring.interactable = false;

        IsAutomatic = true;
        isStarted = true;
        SwitchState(FillingState);
    }

    public void StartFillingState()
    {
        UI.ButtonFilling.interactable = false;
        UI.ButtonAutomatic.interactable = false;
        isStarted = true;
        SwitchState(FillingState);
    }

    public void SwitchState(WaterBaseState state)
    {
        this.state = state;
        state.EnterState(this);

        UI.TextState.text = "STATE: " + state.ToString();
    }

    public void FillingWater()
    {
        GameObject newWaterElement = Instantiate(waterPrefab, spawnPoint.position, Quaternion.identity);
        waterList.Add(newWaterElement);
    }

    public void EnableButton(Button button)
    {
        button.interactable = true;
    }

    public void PouringOut()
    {
        UI.ButtonPouring.interactable = false;
        SwitchState(PouringOutState);
    }

    public void StopSimulation()
    {
        UI.ToggleAutomatic.isOn = false;

        isStarted = false;
        IsAutomatic = false;

        DestroyAllWaterElements();
    }

    public void DestroyAllWaterElements()
    {
        for (int i = 0; i < waterList.Count; i++)
        {
            Destroy(waterList[i].gameObject);
        }

        waterList.Clear();
    }
}