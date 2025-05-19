using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4_delegate_event
{
    public delegate void Notify();  //1.델리게이트 타입 정의
    public delegate void Notify2(); //이벤트 사용을 위한 델리게이트

    public partial class Form1 : Form
    {
        //2.메서드 정의
        static void alarmMessage()
        {
            Console.WriteLine("알람 울림");
        }

        public Form1()
        {
            InitializeComponent();

            alarm a = new alarm();
            alarm2 a2 = new alarm2();   //event
            
            //4.델리게이트 변수에 메서드 할당
            a.onring += alarmMessage;
            a2.onring += alarmMessage;  //event


            //5.실행
            a.onring();
            //a2.onring();    //event -> 컴파일 오류
            a2.trigger();   //클래스 내부 메서드만 가능 -> 안전함

        }

        //3.클래스 정의
        public class alarm
        {
            public Notify onring;   //델리게이트 타입의 변수 선언
        }

        //이벤트 클래스
        public class alarm2
        {
            public event Notify2 onring;

            public void trigger() 
            {
                if (onring != null)
                {
                    onring();
                }
            }

        }

        //버튼 클래스 내부
        //public event EventHanler Click; -> 델리게이트 기반 이벤트
        //button.Click += new EventHanler(button1_Click);
        //button1_Click -> 이벤트 핸들러에 연결되는 델리게이트임

        //이벤트 핸들러 -> .NET에서 미리 정의된 델리게이트 타입
        
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
