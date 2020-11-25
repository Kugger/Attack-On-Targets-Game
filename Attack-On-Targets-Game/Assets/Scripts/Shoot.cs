using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// bodajze najwazniejszy moj skrypt
// to przy jego pomocy zachodzi cale strzelanie
// 
// przypisuje sie ten skrypt do ArrowSpawnPosition
// to z tego skryptu operuje sie predkoscia
// napinania cieciwy
//
// [SerializeField] to troche taki public 
//
// Script by Kacper

public class Shoot : MonoBehaviour
{
    [SerializeField]
    public float pullSpeed; // tworzymy sobie zmienna do operowania szybkosci naciagania

    [SerializeField]
    GameObject arrowPrefab; // to pod tym bedziemy tworzyc klony prefabu

    [SerializeField]
    GameObject arrow; // do tego bedziemy przypisywac prefab naszej strzaly

    [SerializeField]
    public int numberOfArrows = 10; // ilosc strzal ktora bedzie operowal gracz

    [SerializeField]
    GameObject bow; // do tego bedziemy przypisywac prefab naszego luku

    [SerializeField]
    AudioSource drawSound;

    [SerializeField]
    AudioSource looseSound;

    private float maxFieldOfView = 50f;

    [SerializeField]
    Camera cam;

    public float pullAmount = 0; // wartosc naciagu

    bool arrowSlotted = false; // do sprawdzania czy strzala jest na wyekwipowana

    // public int iNumArrow = 0;

    // Start is called before the first frame update
    void Start() // wraz ze startem tworzymy strzale przy luku
    {
        SpawnArrow();
    }

    // Update is called once per frame
    void Update() // przy kazdym odswiezeniu sprawdzamy funkcje ShootLogic
    {
        ShootLogic();

        /*
        GameObject SlowDownTimePU2 = GameObject.Find("SlowDownTimePU2");
        AddArrowsPowerUp numArrow = SlowDownTimePU2.GetComponent<AddArrowsPowerUp>();

        int iNumArrow = numArrow.numberOfArrowsInt;
        */
    }

    void SpawnArrow() // funkcja do spawnowania strzal przy luku
    {
        if (numberOfArrows > 0) // sprawdzamy czy ilosc strzal nie wynosi 0, jesli wynosi to nie spawnujemy nowej strzaly
        {
            arrowSlotted = true; // zmieniamy na true, zeby nie pojawila nam sie tutaj strzala
            arrow = Instantiate(arrowPrefab, transform.position, transform.rotation) as GameObject; // tworzymy klona z wartosciami oryginalnego prefabu
            arrow.transform.parent = transform; // ten klon strzaly ktora spawnujemy staje sie rodzicem
        }
    }

    void ShootLogic() // funkcja odpowiadajaca za strzelanie
    {
        if (numberOfArrows > 0) // sprawdzamy czy jest wiecej strzal niz 0
        {
            if (pullAmount > 100) // jesli pullAmount powyzej 100
                pullAmount = 100; // to pullAmount rowna sie 100, musialem to pisac? xD

            SkinnedMeshRenderer _bowSkin = bow.transform.GetComponent<SkinnedMeshRenderer>(); // przypisujemy tutaj nasz mesh z luku, ktory byl tworzony w blenderze i mozna go modyfikowac
            SkinnedMeshRenderer _arrowSkin = arrow.transform.GetComponent<SkinnedMeshRenderer>(); // przypisujemy tutaj nasz mesh z strzaly, ktora byla tworzona w blenderze i mozna ja modyfikowac
            Rigidbody _arrowRigidB = arrow.transform.GetComponent<Rigidbody>(); // tworzymy rigidbody dla strzaly

            ProjectileAddForce _arrowProjectile = arrow.transform.GetComponent<ProjectileAddForce>(); // tutaj zbieramy rzeczy z ProjectileAddForce

            if (Input.GetMouseButtonDown(0))
                drawSound.Play();

            if (Input.GetMouseButton(0)) // nacisniecie lewego klawisza myszy
            {
                pullAmount += pullSpeed * Time.deltaTime; // zwiekszamy naciag (pullAmount), dzieki deltaTime dziala to niezaleznie od klatkazu

                // cam.fieldOfView -= 0.4f;

                cam.fieldOfView -= pullSpeed * Time.deltaTime * 0.2f;

                if (cam.fieldOfView <= maxFieldOfView)
                    cam.fieldOfView = maxFieldOfView;

                // drawSound.Play();

                // if (pullAmount >= 100)
                //    drawSound.Stop();
            }

            if (Input.GetMouseButtonUp(0)) // podniesienie lewego klawisza myszy
            {
                // gdzies tutaj dodam warunek ze minimalny wymagany naciag musi wynosic 20 czy cos kolo tego,
                // dzieki czemu nie bedzie mozna tak szybko strzelac strzalami, a one nie beda sie w siebie wbijaly ~Kacper

                arrowSlotted = false; // strzaly nie ma przy luku
                _arrowRigidB.isKinematic = false; // wylaczamy oddzialywanie fizyki
                arrow.transform.parent = null; // usuwamy parentowosc, rodzicielstwo?

                _arrowProjectile.shootForce = _arrowProjectile.shootForce * ((pullAmount / 100) + .05f); // w tym miejscu nadajemy sile, ktora jest przekazywana do ProjectileAddForce

                numberOfArrows -= 1; // usuwanie strzal

                pullAmount = 0; // zerujemy naciag

                _arrowProjectile.enabled = true; // uruchamia OnEnable w ProjectileAddForce

                cam.fieldOfView = 65;

                looseSound.Play();

                drawSound.Stop();


                // numberOfArrows = iNumArrow;
            }

            _bowSkin.SetBlendShapeWeight(0, pullAmount); // zmieniamy wyglad luku, czyli go wyginamy
            _arrowSkin.SetBlendShapeWeight(0, pullAmount); // strzala sie cofa

            if (Input.GetMouseButtonDown(0) && arrowSlotted == false) // sluzy do kolejnego strzelania
                SpawnArrow();
        }
    }
}