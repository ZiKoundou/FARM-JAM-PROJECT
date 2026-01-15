using System.Collections.Generic;
using UnityEngine;


public abstract class Plant : MonoBehaviour
{
    //#regions for organization
    #region Fields
    [Header("Plant Stages")]
    //protected means only in this class and inherited classes
    [SerializeField] protected PlantStage[] stages;
    protected int currentStageIndex;
    protected float growthProgress = 0f;
    protected SpriteRenderer spriteRenderer;
    protected PlantStage CurrentStage => stages[currentStageIndex];
    protected bool isPlaced; 
    #endregion
    #region Unity Methods
    protected virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ApplyStage(); // apply stage applies the stages sprite and stat changes to the plant
    }
    #endregion
    #region UnOverridable Base Methods
    public void AddGrowth(float amount)
    {
        growthProgress += amount;

        if (currentStageIndex < stages.Length - 1 &&
            growthProgress >= CurrentStage.growthRequired)
        {
            AdvanceStage();//advancestage goes up an index of the stages list and sets the growth to 0
        }
    }
    protected void AdvanceStage()
    {
        growthProgress = 0f; //reset growth
        currentStageIndex++; //go to next stages index
        ApplyStage(); //apply the stat changes etc.
    }
    #endregion
    #region Overridable Base Methods
    protected virtual void ApplyStage()
    {
        spriteRenderer.sprite = CurrentStage.sprite;//change sprite of plant
        OnStageApplied();//apply stat changes
    }

    protected abstract void OnStageApplied();

    public void OnPlaced()
    {
        isPlaced = true;
    }
    #endregion
}
