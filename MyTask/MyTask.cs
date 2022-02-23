using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask
{
    [Serializable]
    internal class MyTask
    {
        public List<Task> to_make;
        public List<Task> in_process;
        public List<Task> finished;

        public MyTask()
        {
            to_make = new List<Task>();
            in_process = new List<Task>();
            finished = new List<Task>();
        }

        public void goIn_Process(int index)
        {
            Task temp;
            temp = to_make[index];
            to_make.RemoveAt(index);
            temp.statusChange("В процессе");
            in_process.Add(temp);
        }

        public void goFinished(int index)
        {
            Task temp;
            temp = in_process[index];
            in_process.RemoveAt(index);
            temp.statusChange("Закочнено");
            finished.Add(temp);
        }

        public void backTo_make(int index)
        {
            Task temp;
            temp = in_process[index];
            in_process.RemoveAt(index);
            temp.statusChange("Сделать");
            to_make.Add(temp);
        }
        public void backIn_process(int index)
        {
            Task temp;
            temp = finished[index];
            finished.RemoveAt(index);
            temp.statusChange("В процессе");
            in_process.Add(temp);
        }

        public void Done(int index)
        {
            finished.RemoveAt(index);
        }

    }
}
