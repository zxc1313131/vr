using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class FireManager : MonoBehaviour
{
    private XRBaseInteractable grabInteractable; // Ссылка на компонент, который позволяет взаимодействовать с объектом в VR
    public Transform barel; // Точка, откуда вылетают пули (дуло пистолета)
    private string hitTag; // переменная для хранения тега объекта, в который попали
    private int points = 0; //очки
    public static event System.Action<string, int> onTargetHit; //событие onTargetHit

    public void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>(); //берёт компоненты VR

        grabInteractable.activated.AddListener(OnTriggerPressed); //Слушатель событий
    }

    private void OnTriggerPressed(ActivateEventArgs args) //если кнопка нажата
    {
        Fire(); //выполнение функции
    }

    private void Fire() //функция выстрела
    {
        RaycastHit hit; //добавление луча raycast(выстрела)

        if (Physics.Raycast(barel.position, barel.forward, out hit, 300)) //позиция луча, направление луча, если попал - сохраняет в переменную, дистанция
        {
            hitTag = hit.transform.tag; //назначение тега попадания(голова, рука, тело, нога)
            Debug.Log(hitTag); //отладка в консоли

            onTargetHit?.Invoke(hitTag, points); //вызов события

            CalculatePoints(hitTag); //выполнение функции
        }
        
        
    }
    
    private int CalculatePoints(string targetTag) //функция подсчета очков за попадание в определенную часть
    {
        switch (targetTag)
        {
            case "Head": return 120; //голова 120 очков
            case "Body": return 40; //тело 40 очков
            case "Leg": return 20; //рука, нога 20 очков
            case "Hand": return 20;
            default: return 0; //промах или остальное 0 очков
        }
    }
}
