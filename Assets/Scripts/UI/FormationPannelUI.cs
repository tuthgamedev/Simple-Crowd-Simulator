using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FormationPannelUI : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TMP_Text formationText;
    [SerializeField] private TMP_Text selectedText;
    [SerializeField] private TMP_Text slotText;
    [SerializeField] private TMP_Text missingText;
    [SerializeField] private TMP_Text categoryText;

    public void UpdatePanel(
        FormationType formation,
        int selected,
        int slotCount)
    {
        formationText.text =
            $"Formation : {FormationDatabase.GetDisplayName(formation)}";

        selectedText.text =
            $"Selected : {selected}";

        slotText.text =
            $"Ideal Slot : {slotCount}";

        int missing = Mathf.Max(0, slotCount - selected);

        missingText.text =
            $"Missing : {missing}";

        categoryText.text =
            FormationDatabase.UsesIdealSlots(formation)
            ? "Category : Ideal"
            : "Category : Unlimited";
    }
}
