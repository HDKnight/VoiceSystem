using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoiceSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public SpeechSynthesizer voice = new SpeechSynthesizer();   //创建语音实例

        private void button2_Click(object sender, EventArgs e)
        {
            //voice = new SpeechSynthesizer();   //创建语音实例
            //voice.Rate = 1; //设置语速,[-10,10]
            //voice.Volume = 100; //设置音量,[0,100]
            //voice.SpeakAsync(textBox1.Text);  //播放指定的字符串,这是异步朗读

            content = textBox1.Text;
            MyDelegate myDelegate = new MyDelegate(speakParagh);
            //异步调用委托
            myDelegate.BeginInvoke(content, new AsyncCallback(Completed), null);
            //在启动异步线程后，主线程可以继续工作而不需要等待
        }

        private void button1_Click(object sender, EventArgs e)
        {
            voice = new SpeechSynthesizer();   //创建语音实例
            voice.Rate = 1; //设置语速,[-10,10]
            voice.Volume = 100; //设置音量,[0,100]
            voice.Speak(textBox1.Text);  //播放指定的字符串,这是同步朗读
            voice.Dispose();  //释放所有语音资源
        }

        private void button3_Click(object sender, EventArgs e)
        {
            voice.Resume(); //继续朗读
        }

        private void button5_Click(object sender, EventArgs e)
        {
            voice.SpeakAsyncCancelAll();  //取消朗读
        }

        private void button4_Click(object sender, EventArgs e)
        {
            voice.Pause();  //暂停朗读
        }


        delegate void MyDelegate(string content);
        string content = "";
        //SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        ////点击开始按钮
        //private void btnRead_Click(object sender, RoutedEventArgs e)
        //{
        //    content = textBox1.Text;
        //    MyDelegate myDelegate = new MyDelegate(speakParagh);
        //    //异步调用委托
        //    myDelegate.BeginInvoke(content, new AsyncCallback(Completed), null);
        //    //在启动异步线程后，主线程可以继续工作而不需要等待
        //}
        private void speakParagh(string text)
        {
            voice.Rate = 1; //设置语速,[-10,10]
            voice.Volume = 100; //设置音量,[0,100]
            voice.Speak(text);
        }

        //朗读结束后释放资源
        private void Completed(IAsyncResult result)
        {
            voice.SpeakAsyncCancelAll();
        }
    }
}
