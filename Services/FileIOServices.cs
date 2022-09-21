using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAINER.Models;

namespace TRAINER.Services
{
    internal class FileIOServices
    {
        private readonly string PATH;
        public FileIOServices(string path)
        {
            PATH = path;
        }

        public BindingList<USER_WITHOUT_DICTIONARY> LoadData()
        {
            var fileExists = File.Exists(PATH);
            if(!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<USER_WITHOUT_DICTIONARY>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<USER_WITHOUT_DICTIONARY>>(fileText);
            }
            
        }
        public BindingList<UserModel_InTable> LoadDataToTable()
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<UserModel_InTable>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<UserModel_InTable>>(fileText);
            }

        }

        public void SaveData(BindingList<UserModel_InData> USER)
        {
            
                using (StreamWriter writer = File.CreateText(PATH))
                {
                    string output = JsonConvert.SerializeObject(USER);
                    writer.Write(output);
                }
 
        }

        public void SaveTableData(UserModel_InTable USER)
        {

            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(USER);
                writer.Write(output);
            }

        }
    }
}
