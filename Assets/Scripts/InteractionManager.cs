using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class InteractionManager : MonoBehaviour{

    [SerializeField]
    private RigidbodyFirstPersonController playerController;

    [SerializeField]
    private Image handImage;

    [SerializeField]
    private PaperRead paperReadPanel;

    [SerializeField]
    private new PointLight light;

    [SerializeField]
    private OpenDoor openDoor;

    [SerializeField]
    private GameObject key, candleLight;
    private bool hasKey = false;
    private int paperCount = 0;
    
    [SerializeField]
    private float interactDistance;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private FlashLight flashLight;

    private void Start(){
        // отключаем руку
        handImage.gameObject.SetActive(false);
        // отключаем панель с запиской
        paperReadPanel.gameObject.SetActive(false);
    }


    private void Update(){
        Ray ray = new Ray (transform.position, transform.forward);
        RaycastHit raycastHit;
        if(Physics.Raycast(ray, out raycastHit, interactDistance, layerMask)){
            // если рука не отображается
            if(!handImage.gameObject.activeSelf){
                // показать картинку
                handImage.gameObject.SetActive(true);
            }
            // Debug.Log("Ray hit object: " + raycastHit.transform.name);
            // если нажата клавиша Е
            if (Input.GetKeyDown(KeyCode.E)){
                // если смотрю на батарейки
                if(raycastHit.transform.tag == "Battery"){
                    // пополнить заряд фонарика
                    flashLight.AddEnergy();
                    // уничтожить батарейки
                    Destroy(raycastHit.transform.gameObject);
                }

                // если смотрю на записку
                if(raycastHit.transform.tag == "Paper"){
                    // включаем панель
                    paperCount++;
                    paperReadPanel.gameObject.SetActive(true);
                    paperReadPanel.PaperText(paperCount);
                    Destroy(raycastHit.transform.gameObject);
                    // отключаем игрока
                    //playerController.enabled = false;
                }
                // если смотрю на ключ
                if(raycastHit.transform.tag == "Key"){
                    // удаляем ключ
                    Destroy(raycastHit.transform.gameObject);
                    // обновляем переменную
                    hasKey = true;
                }
                // если смотрю на дверь
                if(raycastHit.transform.tag == "Door"){
                    if(paperCount==3)
                    {
                        openDoor.ChangeOpenDoor();
                        Debug.Log("Вы открыли дверь!");
                    }
                    else
                    {
                        Debug.Log("Прочтите еще записки!");
                    }
                    //if(hasKey == false){
                    //    // проиграть звук закрытой двери
                    //    Debug.Log("Дверь закрыта");
                    //}else{
                    //    // открыть дверь
                    //    Debug.Log("Дверь открыта");
                    //    // проиграть звук открытия двери
                    //}
                }
                if(raycastHit.transform.tag == "CandleLight")
                {
                    light.EnableLight();
                }
            }
            if (Input.GetKeyDown(KeyCode.Z)){
                // выключаем панель
                paperReadPanel.gameObject.SetActive(false);
                // включаем игрока
                playerController.enabled = true;
            }
        }else{
            //выключаем картинку
            handImage.gameObject.SetActive(false);
        }
    }
}
