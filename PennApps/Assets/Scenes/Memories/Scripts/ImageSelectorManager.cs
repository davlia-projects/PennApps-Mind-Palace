using UnityEngine;
using System.Collections;
using System.IO;

public class ImageSelectorManager : MonoBehaviour {
    public string directoryPath;
    public SteamVR_TrackedObject trackedObject;
    public GameObject controllerModel;
    public SphereSpawner sphereSpawner;

    MemorySphereController memoryController = null;
    Texture2D texture = new Texture2D(2, 2);
    int textureIndex = -1;
    
    ArrayList textures = new ArrayList();

    void Awake()
    {
        var directoryInfo = new DirectoryInfo(directoryPath);
        FileInfo[] fileInfo = directoryInfo.GetFiles();
        foreach (FileInfo file in fileInfo)
        {
            if (file.Extension == ".jpg")
            {
                Texture2D newTexture = new Texture2D(2, 2);
                newTexture.LoadImage(File.ReadAllBytes(file.FullName));
                textures.Add(newTexture);
            }
            if (file.Extension == ".ogg")
            {
                WWW www = new WWW("file:///" + file.FullName);
                var movieTexture = www.movie;

                textures.Add(movieTexture);
            }
        }
        if (textures.Count != 0)
        {
            textureIndex = 0;
            UpdateTexture();
        }
    }

    void Update()
    {
        // Change image
        int delay = 0;
        if (textures.Count <= 0)
        {
            return;
        }
        var device = SteamVR_Controller.Input((int)trackedObject.index);
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad) && delay <= 0)
        {
            delay = 5;
            textureIndex = (textureIndex + 1) % textures.Count;
            UpdateTexture();
        }
        if (delay > 0)
        {
            delay--;
        }

        // Spawn image
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            GameObject newMemory = sphereSpawner.NewSphere();
            object texture = textures[textureIndex];
            memoryController = newMemory.GetComponent<MemorySphereController>();
            if (texture.GetType() == typeof(Texture2D))
            {
                memoryController.SetPictureTexture((Texture2D)textures[textureIndex]);
            } else if (texture.GetType() == typeof(MovieTexture))
            {
                MovieTexture movie = (MovieTexture)texture;
                movie.Play();
                movie.loop = true;
                memoryController.SetPictureTexture((MovieTexture)textures[textureIndex]);
            }

            memoryController.LockToController();
            GetComponent<Renderer>().enabled = false;
        } else if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            memoryController.ReleaseFromController();
            memoryController = null;
            GetComponent<Renderer>().enabled = true;
        }
    }
    void UpdateTexture()
    {
        if (textures.Count <= 0)
        {
            return;
        }
        if (textures[textureIndex].GetType() == typeof(Texture2D))
        {
            GetComponent<Renderer>().material.mainTexture = (Texture2D)textures[textureIndex];
        } else if (textures[textureIndex].GetType() == typeof(MovieTexture))
        {
            GetComponent<Renderer>().material.mainTexture = (MovieTexture) textures[textureIndex];
            MovieTexture movie = (MovieTexture)textures[textureIndex];
            movie.Play();
            movie.loop = true;
        }
    }
}
