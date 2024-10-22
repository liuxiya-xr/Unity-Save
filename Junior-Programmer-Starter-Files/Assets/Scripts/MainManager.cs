using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static MainManager Instance;//��̬��-��̬�ֶΣ����Ǵ���ʵ��
    public Color color;

    private void Awake()
    {
        if (Instance != null)//����ģʽ
        {
            Destroy(gameObject);//����instance�����ٵ�ǰ����
            return;// return�������Awake��������ִ�к�������
        }
        Instance = this;//����ǰʵ����ֵ����̬����
        DontDestroyOnLoad(gameObject);//��ֹ�л�����ʱ������

        LoadColor();
    }
    [System.Serializable]//���ڱ��һ�����ṹ�壬ʹ����Ա����л���
    class SaveData
    {
        public Color color;

    }
public void SaveColoer()//�洢
    {
        SaveData data = new SaveData();
        data.color = color;
        string json = JsonUtility.ToJson(data);//ʹ�� JsonUtility.ToJson ����ʵ��ת��Ϊ JSON
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);//�ļ���·��
    }
    public void LoadColor()//�ͷ�
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))//
        {
            string json = File.ReadAllText(path);//ʹ�� File.ReadAllText ��ȡ������
            SaveData data = JsonUtility.FromJson<SaveData>(json);//�����л�
            color = data.color;//����Ҫ�Ķ���
        }
    }
}
