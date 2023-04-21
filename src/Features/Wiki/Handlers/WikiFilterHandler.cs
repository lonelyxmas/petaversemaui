﻿using Microsoft.Maui.Controls;

namespace PetaverseMAUI;

public class WikiFilterHandler : Picker
{
    #region [ CTor ]
    public WikiFilterHandler() 
    { }
    #endregion

    #region [Delegates]
    public delegate void SelecedBreedSizeListEventHandler(WikiPageSizeEnum sizeBreed);
    public delegate void SelecedBreedCoatListEventHandler(WikiPageCoatEnum coatBreed);
    public delegate void SelecedBreedSheddingLevelListEventHandler(WikiPageSheddingLevelEnum sheddingLevelBreed);
    public delegate void SelecedBreedEnergyListEventHandler(WikiPageEnergyEnum energyBreed);
    #endregion

    #region [ Event Handlers ]
    public event SelecedBreedSizeListEventHandler SelectBreedSizeList;
    public event SelecedBreedCoatListEventHandler SelectBreedCoatList;
    public event SelecedBreedSheddingLevelListEventHandler SelectBreedSheddingLevelList;
    public event SelecedBreedEnergyListEventHandler SelectBreedEnergyList;
    #endregion

    #region [ Method ]
    private object OnFilterChanged<T>(string oldValue, string newValue) 
        where T : Enum
    { //Not Done Yet
        if (!string.IsNullOrEmpty(newValue))
        {
            return Enum.Parse(typeof(T), newValue, true);
        }
        else
        {
            return ItemsSource;
        }
    }
    #endregion

}