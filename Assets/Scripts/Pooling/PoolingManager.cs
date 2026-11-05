using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PooledItems // Esta clase servira para identificar cada lista
{

    public string Name;                 // El identificador de la lista
    public GameObject objectToPool;     // El objeto que queremos multiplicar
    public int amount;                  // La cantidad de instancias iniciales

}

public class PoolingManager : MonoBehaviour
{

    private static PoolingManager _instance;
    public static PoolingManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PoolingManager>();
            }
            return _instance;
        }
    }

    // La lista de todos los objetos que vamos a multiplicar
    [SerializeField]
    private List<PooledItems> pooledLists = new List<PooledItems>();

    //_items es un diccionario que guarda parejas de datos: nombre-lista de objetos.
    //Este diccionario permite buscar una forma muy rapida un objeto por su nombre
    [SerializeField]
    private Dictionary<string, List<GameObject>> _items = new Dictionary<string, List<GameObject>>();

    void Awake()
    {
        for (int i = 0; i < pooledLists.Count; i++) // Para cada lista de objetos
        {
            PooledItems l = pooledLists[i];
            _items.Add(l.Name, new List<GameObject>()); // Creamos una entrada en el diccionario

            for (int j = 0; j < l.amount; j++)  // Añadimos las copias
            {
                GameObject tmp;
                tmp = Instantiate(l.objectToPool);  // Creamos la copia
                tmp.SetActive(false);               // Desactivamos la copia
                _items[l.Name].Add(tmp);            // La añadimos a la lista
            }
        }
    }

    public GameObject GetPooledObject(string name)  // Para obtener una copia es necesario especificar
                                                    // el nombre de la lista de donde lo vamos a obtener
    {
        List<GameObject> tmp = _items[name];
        // Busca un objeto que este desactivado y lo retorna
        for (int i = 0; i < tmp.Count; i++)
        {
            if (!tmp[i].activeInHierarchy)
            {
                return tmp[i];
            }
        }
        return null;
    }

    public GameObject GetActiveObject(string name)
    {
        List<GameObject> tmp = _items[name];
        // Busca un objeto que este activado y lo retorna
        for (int i = 0; i < tmp.Count; i++)
        {
            if (tmp[i].activeInHierarchy)
            {
                return tmp[i];
            }
        }
        return null;
    }
}
