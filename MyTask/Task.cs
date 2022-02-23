using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask
{
    [Serializable]
    internal class Task
    {
        string description;
        string data;
        string login;
        string status;

        public Task(string login, string des)
        {
            this.data = System.DateTime.Now.ToString("d");
            this.description = des;
            this.status = "Сделать";
            this.login = login;
        }

        public void statusChange(string status)
        {
            this.status = status;
        }

        override
        public string ToString()
        {
            return $"{description} {data} {status}"; 
        }
    }
}
