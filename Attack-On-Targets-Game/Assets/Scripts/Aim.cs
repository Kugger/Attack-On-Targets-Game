using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// skrypt do poruszania kamera przy pomocy myszki
// nie jest idealny, brak mu zatrzymywania sie
// gdy kat wynosi 180, wiec mozna robic salta glowa
//
// [SerializeField] to troche taki public 
//
// Script by Kacper

public class Aim : MonoBehaviour
{
    [SerializeField]
    float verticalMouseSensivity = 3; // czulosc myszki pionowa, im wieksza wartosc tym wolniej sie rusza

    [SerializeField]
    float horizontalMouseSensivity = 1; // czulosc myszki pozioma, im wieksza wartosc tym wolniej sie rusza

    [SerializeField]
    bool aimInvert = false; // warunek zeby odwracac osie

    Rigidbody rigidB; // musimy miec rigidbody zeby przypisac do obiektu

    [SerializeField]
    Camera cam; // do przypisania kamery

    [SerializeField]
    private float verticalMouseSensivityLukauyi = 100f; // czulosc myszki stworzona dla rownowagi powodowanej przez Time.deltatime

    [SerializeField]
    private float horizontalMouseSensivityLukauyi = 100f;

    private float xRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        rigidB = GetComponent<Rigidbody>(); // przypisywanie obiektu w tym wypadku Player
        cam = GetComponentInChildren<Camera>(); // przypisywanie kamery
        Cursor.lockState = CursorLockMode.Locked; // zablokowanie myszki
        Cursor.visible = false; // zeby nie bylo widac kursora
    }
    // Update is called once per frame
    void LateUpdate() // musimy odswiezac caly czas zeby sie rozgladac
    {
        //AimLogic();
        AimLogicLukaiyVersion();
    }

    void AimLogic()
    {
        int _aimModifier = -1; // tutaj sluzy do odwracania osi, taka dodatkowa rzecz
        if (aimInvert)
            _aimModifier = 1;

        float _leftRightValue = Input.GetAxisRaw("Mouse X"); // musimy zebrac informacje o ruchu myszki w osi X
        float _upDownValue = _aimModifier * Input.GetAxisRaw("Mouse Y"); // musimy zebrac informacje o ruchu myszki w osi Y

        Vector3 _rotationX = new Vector3(_upDownValue, 0, 0); // tworzymy wektory po ktorych bedziemy sie poruszac
        Vector3 _rotationY = new Vector3(0, _leftRightValue, 0); // tworzymy wektory po ktorych bedziemy sie poruszac

        rigidB.MoveRotation(rigidB.rotation * Quaternion.Euler(_rotationY / horizontalMouseSensivity)); // nadawanie rotacji
        cam.transform.Rotate(_rotationX / verticalMouseSensivity); // i dawanie tych wartosci do kamery
    }

    void AimLogicLukaiyVersion()
    {
        //Zbieranie danych z myszki
        float mouseX = Input.GetAxis("Mouse X") * verticalMouseSensivityLukauyi * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * horizontalMouseSensivityLukauyi * Time.deltaTime;

        xRotation -= mouseY; // odejmowanie by nie trzepalo - tak z doswiadczen przy plusie trzepalo kamera
        xRotation = Mathf.Clamp(xRotation, -90f, 30f); // zablokowanie rotacji 60st w gore i 40 w dol


        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // nadanie kamerze rotacji Vektorem 3d
        rigidB.transform.Rotate(Vector3.up * mouseX);   //nadanie mozliwosci obracania postacia w prawo i w lewo
    }
}