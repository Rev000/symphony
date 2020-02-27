using System;

namespace RevLibrary.Tools
{
    public static class Application
    {
        public static string Root
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory; 
            }
        }
    }
}
