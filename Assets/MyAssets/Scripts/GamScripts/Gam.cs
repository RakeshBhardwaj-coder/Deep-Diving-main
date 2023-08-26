using UnityEngine;
public enum GamType
{
    Gold,
    Diamond,
    Ruby
}
public class Gam : MonoBehaviour
{
    //Singlton
    private static Gam _instance;

    public static Gam Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Gam>();
            }

            return _instance;
        }
    }
    public GamType Type { get; private set; }

    public Gam(GamType gamType)
    {
        Type = gamType;
    }

    public GamType gamType;
    private Gam gam;
    private void Start()
    {
        gam= new Gam(gamType);

    }
}
