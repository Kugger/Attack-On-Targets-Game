using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

// jest to prosty skrypt ktorego celem jest 
// odwzorowania trafienia co za tym idzie
// uzyskania punktow
//
// skrypt ten przypisuje sie do meshow
// odpowiednich obszarow tarcz ktore
// maja rozne punkty ktore mozna zmienic
// w samym juz unity poniewaz ilosc
// punktow to public int
//
// w tym skrypcie powinno znalezc sie
// uruchamianie particle system po dezaktywowaniu
// obiektu ale to jeszcze nie jest gotowe
// zajmie sie tym Kacper w wolnym czasie
//
// wprawny gracz moze zaliczyc oba pola
//
// Script by Kacper

public class PointTracker : MonoBehaviour
{
    public int value = 50; // int punktow ktore da sie zdobyc za trafienie

    public ParticleSystem boom;

    [SerializeField]
    AudioSource puffSound;

    // Start is called before the first frame update
    void Start() // bezuzyteczne, do usuniecia w przyszlosci
    {
        
    }
    // Update is called once per frame
    void Update() // bezuzyteczne, do usuniecia w przyszlosci
    {
        
    }

    void OnTriggerEnter(Collider other) // bezuzyteczne, do usuniecia w przyszlosci
    {
        ScoreManager.instance.score += value;
    }

    void OnCollisionEnter(Collision collision)
    {
        puffSound.Play();

        Instantiate(boom, transform.position, transform.rotation);
        boom.Play();
        // Debug.Log("I'm booming!");

        ScoreManager.instance.score += value; // przypisywanie punktow do obecnego wyniku, korzysta z instancji ze ScoreManager
        // Destroy(transform.parent.gameObject); // nie odkomentowac tego
        transform.parent.gameObject.SetActive(false); // wylacza calkowicie obiekt rodzic, w tym przypadku tarcze
        collision.gameObject.SetActive(false);  // wylacza obiekt ktory trafil w przypisany obiekt, w tym przypadku mesh z tarczy
    }
}
