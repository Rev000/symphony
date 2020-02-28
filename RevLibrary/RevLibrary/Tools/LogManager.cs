using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace RevLibrary.Tools
{
    public class LogManager
    {
        private string _path;

        #region Constructors
        public LogManager(string path)
        {
            _path = path;
            _SetLogPath();
        }

        public LogManager()
            :this(Path.Combine(Application.Root, "Log")) //매개변수를 넘겨줌 
        {
        }
        #endregion



        #region Methods
        private void _SetLogPath()
        {
            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);

            string logFile = DateTime.Now.ToString("yyyyMMdd") + ".txt";
            _path = Path.Combine(_path, logFile);
        }

        public void Write(string data)
        {
            using (StreamWriter writer = new StreamWriter(_path,true)) //using 안의 스코프는 프로그램이 using 스코프 안에 있는 경우에만 리소스를 할당하고 
                                                                       //스코프 밖에 있는 경우에는 리소스를 반환 한다  
            {
                try
                {
                    writer.Write(data);
                }
                catch(Exception ex)
                { }
            }
        }

        public void WriteLine(string data)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_path, true))
                {
                    writer.WriteLine(DateTime.Now.ToString("yyyyMMdd HH:mm:ss.fff\t") + data);
                }
            }
            catch (Exception ex)
            { }
        }
        #endregion
    }
}
