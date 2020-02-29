using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace RevLibrary.Tools
{
    public enum LogType { daily, Monthly}

    public class LogManager
    {
        private string _path;

        #region Constructors
        public LogManager(string path, LogType logType,string prefix, string postfix)
        {
            _path = path;
            _SetLogPath(logType, prefix, postfix);
        }

        public LogManager( string prefix, string postfix)
            :this(Path.Combine(Application.Root,"Log"), LogType.daily, prefix, postfix)
        {

        }

        public LogManager()
            :this(Path.Combine(Application.Root, "Log"), LogType.daily, null, null) //매개변수를 넘겨줌 
        {
        }
        #endregion



        #region MethodsS
        private void _SetLogPath(LogType logtype, string prefix, string postfix)
        {

            string path = String.Empty; //중간 경로 
            string name = String.Empty;
            
            switch (logtype)
            {
                case LogType.daily:
                    path = string.Format(@"{0}\{1}\", DateTime.Now.Year, DateTime.Now.ToString("MM"));
                    name = DateTime.Now.ToString("yyyyMMdd");
                    break;
                case LogType.Monthly:
                    path = String.Format(@"{0}\", DateTime.Now.Year);
                    name = DateTime.Now.ToString("yyyyMM");
                    break;
            }

            _path = Path.Combine(_path, path);
            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);


            if (!string.IsNullOrEmpty(prefix))
                name = prefix + name;

            if (!string.IsNullOrEmpty(postfix))
                name = name + postfix;

            name += ".txt";

            _path = Path.Combine(_path, name);
        }

        public void Write(string data)
        {
            using (StreamWriter writer = new StreamWriter(_path,true)) //using 안의 스코프는 프로그램이 using 스코프 안에 있는 경우에만 리소스를 할당하고                                                         
            {                                                          //스코프 밖에 있는 경우에는 리소스를 반환 한다  
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
