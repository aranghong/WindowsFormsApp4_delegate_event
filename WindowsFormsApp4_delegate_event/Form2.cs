using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp4_delegate_event
{

    public delegate void EventDelegate();

    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            EventManager e = new EventManager();
            e.insert("hi", hi); //이벤트 추가
            e.execution("hi");  //이벤트 실행
            e.delete("hi", hi); //이벤트 삭제

            e.insert("bye", bye);
            e.execution("bye");


        }

        void hi()
        {
            //MessageBox.Show($"hi");
            Console.WriteLine("hi");

        }

        void bye()
        {
            //MessageBox.Show($"bye");
            Console.WriteLine("bye");
        }

    }

    public class EventManager
    {

        private static Dictionary<string, EventDelegate> eventdic = new Dictionary<string, EventDelegate>();
        public event EventDelegate onring;

        //이벤트 추가
        public void insert(string name, EventDelegate method)
        {
            eventdic[name] = method;
            Console.WriteLine("이벤트 추가");
        }

        //이벤트 삭제
        public void delete(string name, EventDelegate method)
        {
            if (eventdic.ContainsKey(name))
            {
                eventdic.Remove(name);
                Console.WriteLine("이벤트 삭제");
            }
        }

        //이벤트 실행
        public void execution(string name)
        {
            if (eventdic.ContainsKey(name))
            {
                eventdic[name]?.Invoke();
                Console.WriteLine("이벤트 실행");
            }
            else
            {
                //MessageBox.Show($"[{name}] 이벤트가 존재하지 않습니다.");
                Console.WriteLine($"[{name}] 이벤트 존재하지 않음");
            }
        }

    }

}
