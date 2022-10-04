using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Collections.Generic;

namespace Game.SaveLoadSystem
{
    public static class SaveSystem
    {
        private const string savingFolder = "Saves/";
        private const string ending = ".xml";

        private static string absoluteSavingPath = Application.persistentDataPath + "/" + savingFolder;
        
        
        private const string savingLevel = "CurrentLevelData/";
        private const string savingPlayer = "PlayerData/";
        private const string savingCollectibles = "CollectiblesData/";
        


        public static string SavingLevel { get => savingLevel; }
        public static string SavingCollectibles { get => savingCollectibles; }
        public static string SavingPlayer { get => savingPlayer; }

        #region LoadTypes

        public static T Load<T>(string savingPath) where T : class
        {
            string path = CreatePath(savingPath);


            if (!CheckIfFileExists(savingPath))
                return null;

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);

            T data = binaryFormatter.Deserialize(fs) as T;

            fs.Close();

            return data;
        }


            #region Load Basic

        public static string LoadString(string savingPath)
        {
            string path = CreatePath(savingPath);

            if (!CheckIfFileExists(savingPath))
                return null;

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);

            string data = binaryFormatter.Deserialize(fs) as string;
            fs.Close();

            return data;
        }
        
        public static bool LoadBool(string savingPath)
        {
            string path = CreatePath(savingPath);

            if (!CheckIfFileExists(savingPath))
                return false;

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);

            string data = binaryFormatter.Deserialize(fs) as string;
            fs.Close();

            if (data == "True")
                return true;
            else
                return false;
        }

        public static int LoadInt(string savingPath)
        {
            string path = CreatePath(savingPath);

            if (!CheckIfFileExists(savingPath))
                return 0;

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);

            int data = (int)binaryFormatter.Deserialize(fs);
            fs.Close();

            return data;
        }

        public static float LoadFloat(string savingPath)
        {
            string path = CreatePath(savingPath);

            if (!CheckIfFileExists(savingPath))
                return 0f;

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);

            float data = (float)binaryFormatter.Deserialize(fs);
            fs.Close();

            return data;
        }

        public static double LoadDouble(string savingPath)
        {
            string path = CreatePath(savingPath);

            if (!CheckIfFileExists(savingPath))
                return 0;

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);

            double data = (double)binaryFormatter.Deserialize(fs);
            fs.Close();

            return data;
        }

        public static Vector3 LoadVector3(string savingPath)
        {
            string path = CreatePath(savingPath);

            if (!CheckIfFileExists(savingPath))
                return Vector3.zero;

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);

            var data = binaryFormatter.Deserialize(fs) as List<float>;

            fs.Close();

            Vector3 value = new Vector3(data[0], data[1], data[2]);

            return value;
        }

        public static Vector2 LoadVector2(string savingPath)
        {
            string path = CreatePath(savingPath);

            if (!CheckIfFileExists(savingPath))
                return Vector2.zero;

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);


            var data = binaryFormatter.Deserialize(fs) as List<float>;

            fs.Close();

            Vector2 value = new Vector2(data[0], data[1]);

            return value;
        }

        #endregion Load Basic


            #region Load Lists

        public static List<string> LoadStringList(string savingPath)
        {
            string path = CreatePath(savingPath);

            if (!CheckIfFileExists(savingPath))
                return null;

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);

            List<string> data = new List<string>();
            data = binaryFormatter.Deserialize(fs) as List<string>;

            fs.Close();

            return data;
        }

        public static List<bool> LoadBoolList(string savingPath)
        {
            string path = CreatePath(savingPath);

            if (!CheckIfFileExists(savingPath))
                return null;

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);

            List<string> data = new List<string>();
            data = binaryFormatter.Deserialize(fs) as List<string>;

            List<bool> realData = new List<bool>();

            foreach(string d in data)
            {
                if (d == "True")
                    realData.Add(true);
                else
                    realData.Add(false);
            }

            fs.Close();

            return realData;
        }

        public static List<int> LoadIntList(string savingPath)
        {
            string path = CreatePath(savingPath);

            if (!CheckIfFileExists(savingPath))
                return null;

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);

            List<int> data = new List<int>();
            data = binaryFormatter.Deserialize(fs) as List<int>;

            fs.Close();

            return data;
        }

        public static List<float> LoadFloatList(string savingPath)
        {
            string path = CreatePath(savingPath);

            if (!CheckIfFileExists(savingPath))
                return null;

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);

            List<float> data = new List<float>();
            data = binaryFormatter.Deserialize(fs) as List<float>;

            fs.Close();

            return data;
        }

        public static List<double> LoadDoubleList(string savingPath)
        {
            string path = CreatePath(savingPath);

            if (!CheckIfFileExists(savingPath))
                return null;

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);

            List<double> data = new List<double>();
            data = binaryFormatter.Deserialize(fs) as List<double>;

            fs.Close();

            return data;
        }

        public static List<Vector3> LoadVector3List(string savingPath)
        {
            string path = CreatePath(savingPath);

            if (!CheckIfFileExists(savingPath))
                return null;

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);

            List<List<float>> data = new List<List<float>>();
            data = binaryFormatter.Deserialize(fs) as List<List<float>>;

            List<Vector3> realData = new List<Vector3>();

            foreach(List<float> v in data)
            {
                realData.Add(new Vector3(v[0], v[1], v[2]));
            }

            fs.Close();

            return realData;
        }

        public static List<Vector2> LoadVector2List(string savingPath)
        {
            string path = CreatePath(savingPath);

            if (!CheckIfFileExists(savingPath))
                return null;

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);

            List<List<float>> data = new List<List<float>>();
            data = binaryFormatter.Deserialize(fs) as List<List<float>>;

            List<Vector2> realData = new List<Vector2>();

            foreach (List<float> v in data)
            {
                realData.Add(new Vector2(v[0], v[1]));
            }

            fs.Close();

            return realData;
        }

        #endregion Load Lists


        #endregion LoadTypes


        #region SaveTypes

        public static void Save<T>(T savingValue, string savingPath) where T : new()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            string path = CreatePath(savingPath);
            CreateDirectoryForSaves(path);

            FileStream fs = new FileStream(path, FileMode.Create);

            T customData = new T();

            customData = savingValue;

            formatter.Serialize(fs, customData);
            fs.Close();
        }


            #region Save Basic

        public static void SaveString(string savingValue, string savingPath)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            string path = CreatePath(savingPath);
            CreateDirectoryForSaves(path);

            FileStream fs = new FileStream(path, FileMode.Create);

            formatter.Serialize(fs, savingValue);
            fs.Close();
        }

        public static void SaveBool(bool savingValue, string savingPath)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            string path = CreatePath(savingPath);
            CreateDirectoryForSaves(path);

            FileStream fs = new FileStream(path, FileMode.Create);

            formatter.Serialize(fs, savingValue.ToString());
            fs.Close();
        }

        public static void SaveInt(int savingValue, string savingPath)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            string path = CreatePath(savingPath);
            CreateDirectoryForSaves(path);

            FileStream fs = new FileStream(path, FileMode.Create);

            formatter.Serialize(fs, savingValue);
            fs.Close();
        }

        public static void SaveFloat(float savingValue, string savingPath)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            string path = CreatePath(savingPath);
            CreateDirectoryForSaves(path);

            FileStream fs = new FileStream(path, FileMode.Create);

            formatter.Serialize(fs, savingValue);
            fs.Close();
        }

        public static void SaveDouble(double savingValue, string savingPath)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            string path = CreatePath(savingPath);
            CreateDirectoryForSaves(path);

            FileStream fs = new FileStream(path, FileMode.Create);

            formatter.Serialize(fs, savingValue);
            fs.Close();
        }

        public static void SaveVector3(Vector3 savingValue, string savingPath)
        {

            BinaryFormatter formatter = new BinaryFormatter();

            string path = CreatePath(savingPath);
            CreateDirectoryForSaves(path);

            FileStream fs = new FileStream(path, FileMode.Create);

            List<float> values = new List<float>();

            values.Add(savingValue.x);
            values.Add(savingValue.y);
            values.Add(savingValue.z);

            formatter.Serialize(fs, values);
            fs.Close();
        }

        public static void SaveVector2(Vector2 savingValue, string savingPath)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            string path = CreatePath(savingPath);
            CreateDirectoryForSaves(path);

            FileStream fs = new FileStream(path, FileMode.Create);

            List<float> values = new List<float>();

            values.Add(savingValue.x);
            values.Add(savingValue.y);
            
            formatter.Serialize(fs, values);
            fs.Close();
        }

        #endregion Save Basic


            #region Save Lists

        public static void SaveStringList(List<string> savingValue, string savingPath)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            string path = CreatePath(savingPath);
            CreateDirectoryForSaves(path);

            FileStream fs = new FileStream(path, FileMode.Create);

            formatter.Serialize(fs, savingValue);
            fs.Close();
        }

        public static void SaveBoolList(List<bool> savingValue, string savingPath)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            string path = CreatePath(savingPath);
            CreateDirectoryForSaves(path);

            FileStream fs = new FileStream(path, FileMode.Create);


            List<string> values = new List<string>();

            foreach(bool val in savingValue)
            {
                values.Add(val.ToString());
            }

            formatter.Serialize(fs, values);
            fs.Close();
        }

        public static void SaveIntList(List<int> savingValue, string savingPath)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            string path = CreatePath(savingPath);
            CreateDirectoryForSaves(path);

            FileStream fs = new FileStream(path, FileMode.Create);

            formatter.Serialize(fs, savingValue);
            fs.Close();
        }

        public static void SaveFloatList(List<float> savingValue, string savingPath)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            string path = CreatePath(savingPath);
            CreateDirectoryForSaves(path);

            FileStream fs = new FileStream(path, FileMode.Create);

            formatter.Serialize(fs, savingValue);
            fs.Close();
        }

        public static void SaveDoubleList(List<double> savingValue, string savingPath)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            string path = CreatePath(savingPath);
            CreateDirectoryForSaves(path);

            FileStream fs = new FileStream(path, FileMode.Create);

            formatter.Serialize(fs, savingValue);
            fs.Close();
        }

        public static void SaveVector3List(List<Vector3> savingValue, string savingPath)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            string path = CreatePath(savingPath);
            CreateDirectoryForSaves(path);

            FileStream fs = new FileStream(path, FileMode.Create);

            List<List<float>> values = new List<List<float>>();

            foreach(Vector3 v in savingValue)
            {
                List<float> temp = new List<float>();
                temp.Add(v.x);
                temp.Add(v.y);
                temp.Add(v.z);
                values.Add(temp);
            }

            formatter.Serialize(fs, values);
            fs.Close();
        }

        public static void SaveVector2List(List<Vector2> savingValue, string savingPath)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            string path = CreatePath(savingPath);
            CreateDirectoryForSaves(path);

            FileStream fs = new FileStream(path, FileMode.Create);

            List<List<float>> values = new List<List<float>>();

            foreach (Vector2 v in savingValue)
            {
                List<float> temp = new List<float>();
                temp.Add(v.x);
                temp.Add(v.y);
                values.Add(temp);
            }

            formatter.Serialize(fs, values);
            fs.Close();
        }

        #endregion Save Lists


        #endregion LoadTypes

        public static bool CheckIfFileExists(string savingPath)
        {
            string path = CreatePath(savingPath);
            return File.Exists(path);
        }

        public static void DeleteAllSaves()
        {
            if(Directory.Exists(absoluteSavingPath))
            {
                Directory.Delete(absoluteSavingPath, true);
            }
        }

        public static void DeleteOneSave(string savingPath)
        {
            string path = CreatePath(savingPath);
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
        }

        private static void CreateDirectoryForSaves(string path)
        {
            int lastIndicator = path.LastIndexOf("/");
            int numberOfWordsToDelete = (path.Length - lastIndicator);
            string newPath = path.Remove(lastIndicator, numberOfWordsToDelete);

            if (Directory.Exists(newPath))
                return;

            Directory.CreateDirectory(newPath);
        }

        private static string CreatePath(string rawPath)
        {
            string finalPath = absoluteSavingPath + rawPath + ending;
            return finalPath;
        }
    }
}
