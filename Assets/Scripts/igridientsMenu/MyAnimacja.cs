using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//clasa która animuje podany obrazek kiedy naciskamy przycisk Lecimy gotować z licziliem 0 i potem zapuskamy metode ToggleInteraction()
public class MyAnimacja : MonoBehaviour
{
    public Image image;// obrazek
    public MyButton button;//obiekt Mybuton
    public float moveDuration = 2.0f; // Czas trwania animacji w sekundach, zwiększając tę wartość, animacja będzie wolniejsza 
    public Vector2 startPosition;//początkowa pozycja obrazku
    public Vector2 endPosition;//końcoa pozycja obrazku

    private bool isMoving = false;//zmienna czy jest animacja
    private float moveTimer = 0.0f;//Licznik czasu trwania animacji.


    private void Update()
    {
        if (isMoving)//jeśli zmiena true to można animować
        {
            moveTimer += Time.deltaTime;//Zwiększa licznik czasu o czas trwania poprzedniej klatki
            
            float t = Mathf.Clamp01(moveTimer / moveDuration);//Oblicza wartość t jako stopień ukończenia animacji (wartość od 0 do 1) na podstawie czasu trwania animacji
            image.rectTransform.anchoredPosition = Vector2.Lerp(startPosition, endPosition, t);//Interpoluje pozycję obrazka między pozycją początkową a pozycją końcową na podstawie wartości t, aby osiągnąć efekt płynnego ruchu
           
            if (t >= 1.0f)//sprawdza czy animacja jest skonczona
            {
                isMoving = false;//ustawiamy że animacja skonczona
                moveTimer = 0.0f;//Resetuje licznik czasu
                button.ToggleInteraction(); // Uruchamiamy po zakończeniu przesuwania obrazka
                SceneManager.LoadScene("FightScreen");
               

            }
        }
    }

    public void StartImageMove()//metoda rozpoczyna animację obrazka 
    {
        if (button.animacja)//jesli zmienna aniamacja jest true to rozpoczyna się animacja 
        {
            isMoving = true;//ustawiamy że można rozpoczynać animację
            image.rectTransform.anchoredPosition = startPosition;//Ustawia pozycję obrazka na pozycję początkową przed rozpoczę
        }
    }
}