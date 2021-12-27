using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bag : MonoBehaviour
{
    [SerializeField] private GameObject openSprite;
    [SerializeField] private GameObject closeSprite;
    [SerializeField] private GameObject sellectSprite;

    public UnityEvent openEvent = new UnityEvent();
    public UnityEvent closeEvent = new UnityEvent();
    public UnityEvent switchSellectEvent;
    public UnityEvent sellectEvent;
    public UnityEvent notSellectEvent;

    private bool isOpen = true;
    private bool isSellect = true;

    public bool IsOpen { get => isOpen; private set => isOpen = value; }

    private void Start()
    {
        if (openEvent == null)
            openEvent = new UnityEvent();
        if (closeEvent == null)
            closeEvent = new UnityEvent();

        Reset();
    }
    public void Open()
    {
        if (!isOpen)
        {
            closeSprite.SetActive(false);
            openSprite.SetActive(true);
            openEvent.Invoke();
            //NotSellect();
        }
        isOpen = true;
        
    }
    public void Close()
    {
        if (isOpen)
        {
            closeSprite.SetActive(true);
            openSprite.SetActive(false);
            closeEvent?.Invoke();
            //NotSellect();

        }
        isOpen = false;
    }

    public void SwitchSellect()
    {
        if (isSellect) NotSellect();
        else Sellect();

        switchSellectEvent?.Invoke();
    }


    public void Sellect()
    {
        sellectSprite.SetActive(true);
        isSellect = true;
        sellectEvent?.Invoke();
    }
    public void NotSellect()
    {
        sellectSprite.SetActive(false);
        isSellect = false;
        notSellectEvent?.Invoke();
    }



    public void Reset()
    {
        closeSprite.SetActive(true);
        openSprite.SetActive(false);
        isOpen = false;
        NotSellect();
    }
}
