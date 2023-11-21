using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListContent : MonoBehaviour
{
    // khởi tạo 1 list chứa color dc kéo vào
    public List<GameObject> listColor;
    public  bool CheckColor(){
        // kiểm tra xem game object có phải không màu ko
        var c_color = gameObject.GetComponent<SpriteRenderer>().color;
        // nếi có thì trả về true
        if(c_color == new Color(1f, 1f, 1f, 1f)){
            return true;
        }
        return false;
    }
}
