using DomainLibrary.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DomainLibrary.DB
{
    public class FileSystemDB<T> : IDb<T> where T : BaseEntity
    {
        private string _dbFolder;
        private string _dbPath;
        private string _idPath;

        public FileSystemDB()
        {
            _dbFolder = @"..\..\..\DB";
            _dbPath = $@"{_dbFolder}\{typeof(T).Name}.json";
            _idPath = $@"{_dbFolder}\id.txt";

            if (!Directory.Exists(_dbFolder))
            {
                Directory.CreateDirectory(_dbFolder);
            }

            if (!File.Exists(_dbPath))
            {
                File.Create(_dbPath).Close();
            }

            if (!File.Exists(_idPath))
            {
                File.Create(_idPath).Close();
            }
        }
        // 1) --------GET ALL----------
        public List<T> GetAll()
        {
            using (StreamReader sr = new StreamReader(_dbPath))
            {
                string resultString = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<List<T>>(resultString);
            }
        }
        // 2) -------GET BY ID---------
        public T GetById(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id == id);
        }
        // 3) -------INSERT-----------
        public int Insert(T entityToInsert)
        {
            List<T> newList = new List<T>();

            using (StreamReader sr = new StreamReader(_dbPath))
            {
                newList = JsonConvert.DeserializeObject<List<T>>(sr.ReadToEnd());
            }
            if (newList == null)
                newList = new List<T>();

            entityToInsert.Id = GenerateId();

            newList.Add(entityToInsert);

            ReWriteData(_dbPath, newList);

            return entityToInsert.Id;
        }
        // 4) -----------REMOVE BY ID-------------
        public void RemoveById(int id)
        {
            List<T> data = new List<T>();

            using (StreamReader sr = new StreamReader(_dbPath))
            {
                data = JsonConvert.DeserializeObject<List<T>>(sr.ReadToEnd());
            }

            T itemToBeRemoved = data.SingleOrDefault(x => x.Id == id);

            if (itemToBeRemoved != null)
            {
                data.Remove(itemToBeRemoved);
                ReWriteData(_dbPath, data);
            }
        }
        // 5) -------------------UPDATE ENTITY--------------
        public void Update(T entity)
        {
            List<T> data = new List<T>();

            using (StreamReader sr = new StreamReader(_dbPath))
            {
                data = JsonConvert.DeserializeObject<List<T>>(sr.ReadToEnd());
            }

            T itemToBeUpdated = data.SingleOrDefault(x => x.Id == entity.Id);
            if (itemToBeUpdated != null)
            {
                data[data.IndexOf(itemToBeUpdated)] = entity;
                ReWriteData(_dbPath, data);
            }
        }

        //-------------------METODI SAMO NA OVAA KLASA--------------------

        // 1) -------------GENERATE ID------------
        private int GenerateId()
        {
            int id = 1;

            using (StreamReader sr = new StreamReader(_idPath))
            {
                string currentId = sr.ReadLine();
                if (currentId != null)
                    id = int.Parse(currentId);
            }

            using (StreamWriter sw = new StreamWriter(_idPath))
            {
                sw.WriteLine(id + 1);
            }

            return id;
        }
        // 2) -----------WRITE / RE-WRITE IN FILE---------
        private void ReWriteData(string path, List<T> updatedList)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(JsonConvert.SerializeObject(updatedList));
            }
        }

    }
}
