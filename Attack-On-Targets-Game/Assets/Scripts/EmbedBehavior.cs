using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// skrypt odpowiadajacy za wbijanie strzal
// po spotakniu przeszkody (nawet siebie, 
// mozliwe ze Kacper naprawi to w przyszlosi)
//
// skrypt ten przypisuje sie do prefabu
// strzaly gdy napotka przeszkode zatrzymuje
// sie i pozostaje w miejscu
//
// zachowanie zalezy w duzej mierze od box
// collider prefabu dlatego czasami dziwnie
// sie wbija
//
// Script by Kacper

public class EmbedBehavior : MonoBehaviour
{
    Rigidbody rigidB; // stworzenie obiektu fizycznego

    [SerializeField]
    AudioSource hitSound;

    // Start is called before the first frame update
    void Start()
    {
        rigidB = GetComponent<Rigidbody>(); // przypisanie obiektu
    }

    // Update is called once per frame
    void Update() // bezuzyteczne, do usuniecia w przyszlosci
    {

    }

    void Embed()
    {
        hitSound.Play();

        transform.GetComponent<ProjectileAddForce>().enabled = false; // wylaczenie sily nadanej obiektowi
        rigidB.velocity = Vector3.zero; // zatrzymanie obiektu, wyzerowanie jego pozycji
        rigidB.useGravity = false; // wylaczenie grawitacji
        rigidB.isKinematic = true; // wlaczenie oddzialywania fizyki, lepiej nie dawac na false
        rigidB.detectCollisions = false; // teraz strzaly nie wbijaja sie w siebie, ale moze powodowac problemy
    }

    void OnCollisionEnter(Collision collision)
    {
        Embed(); // uruchomienie funkcji Embed przy kolizji
    }
}