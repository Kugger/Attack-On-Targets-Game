using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// skrypt odpowiadajacy za caly ruch strzaly
// to on nadaje sile ktora pozniej napedza
// strzale
//
// skrypt ten przypisuje sie do prefabu strzaly
// i co najwazniejsze ma byc NIEAKTYWNY
// (dlaczego tak? nie pytajcie dlugo mi to zajelo)
// pozniej mozna nadac sile z ktora bedzie
// wystrzeliwana strzala
//
// ta wartosc nie moze byc za duza bo strzala
// zacznie przenikac przez wszelakie obiekty
// nie potrafie tego na ten moment wyjasnic
// obecna sila to 1200 i dziala odpowiednio
//
// Kacper dopiero pozniej zdal sobie sprawe
// ze mogl przyczepic rigidbody w dwoch miejscach
// strzaly i na to samo by wyszlo
// przynajmniej ladnie wyglada

public class ProjectileAddForce : MonoBehaviour
{
    Rigidbody rigidB; // stworzenie obiektu fizycznego

    public float shootForce = 2000; // wartosc sily mozna ja pozniej zmieniac

    void OnEnable() // uruchamiane po wystrzeleniu strzaly
    {
        rigidB = GetComponent<Rigidbody>(); // przypisanie rigidbody do prefab
        rigidB.velocity = Vector3.zero; // wyzerowanie pozycji prefabu
        ApplyForce(); // funkcja nadajaca sile
    }

    // Update is called once per frame
    void Update() // funkcja update zeby przy kazdym odswiezeniu wlacza sie funkcja obracajaca strzale w powietrzu
    {
        SpinObjectInAir(); // wywolujemy funkcje odpowiadajaca za obracanie strzaly
    }

    void ApplyForce() // tutaj nadajemy sile strzale
    {
        rigidB.AddRelativeForce(Vector3.forward * shootForce); // naszemu obiektowi nadajemy kierunek lotu i zarazem sile, shootForce patrz w skrypt Shoot
    }

    void SpinObjectInAir() // funkcja odpowiadajaca za obrot strzaly w powietrzu, w glownej mierze matematyka
    {
        float _yVelocity = rigidB.velocity.y; // zbieramy pozycje y z obiektu
        float _zVelocity = rigidB.velocity.z; // zbieramy pozycje z z obiektu
        float _xVelocity = rigidB.velocity.x; // zbieramy pozycje x z obiektu

        float _combinedVelocity = Mathf.Sqrt(_xVelocity * _xVelocity + _zVelocity * _zVelocity); // obliczanie trasy z rownania Pitagorasa, trzeba to sobie wyobrazic

        float _fallAngle = -1 * Mathf.Atan2(_yVelocity, _combinedVelocity) * 180 / Mathf.PI; // obliczanie kata tak zeby strzala spadala grotem w dol

        transform.eulerAngles = new Vector3(_fallAngle, transform.eulerAngles.y, transform.eulerAngles.z); // przypisujemy wartosci naszemu obiektowi
    }
}