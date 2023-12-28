using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    private int ownerId;
    private Card Myself;
    private GameManager myManager;
    [SerializeField] private TextMeshProUGUI cost;
    [SerializeField] private TextMeshProUGUI power;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;
    public void Spawned(Card me, GameManager manager)
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
