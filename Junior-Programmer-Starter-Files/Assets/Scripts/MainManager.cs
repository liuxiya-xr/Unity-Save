using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static MainManager Instance;//静态类-静态字段，而非创建实例
    public Color color;

    private void Awake()
    {
        if (Instance != null)//单例模式
        {
            Destroy(gameObject);//而非instance，销毁当前对象
            return;// return代表结束Awake方法，不执行后续代码
        }
        Instance = this;//将当前实例赋值给静态变量
        DontDestroyOnLoad(gameObject);//防止切换场景时被销毁

        LoadColor();
    }
    [System.Serializable]//用于标记一个类或结构体，使其可以被序列化。
    class SaveData
    {
        public Color color;

    }
public void SaveColoer()//存储
    {
        SaveData data = new SaveData();
        data.color = color;
        string json = JsonUtility.ToJson(data);//使用 JsonUtility.ToJson 将该实例转换为 JSON
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);//文件的路径
    }
    public void LoadColor()//释放
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))//
        {
            string json = File.ReadAllText(path);//使用 File.ReadAllText 读取其内容
            SaveData data = JsonUtility.FromJson<SaveData>(json);//反序列化
            color = data.color;//最终要的东西
        }
    }
}
