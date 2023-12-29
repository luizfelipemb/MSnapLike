using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    private CardBase Myself;
    private GameManager myManager;
    [SerializeField] private TextMeshProUGUI cost;
    [SerializeField] private TextMeshProUGUI power;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;
    public void Spawned(CardBase me, GameManager manager)
    {
        Myself = me;
        myManager = manager;
        cost.text = Myself.cost.ToString();
        power.text = Myself.power.ToString();
        title.text = Myself.name.ToString();
        description.text = Myself.description.ToString();
    }
    public void OnClick()
    {
        myManager.TryPlayCardBy(1, Myself);
    }

}
