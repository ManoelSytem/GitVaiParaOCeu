using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GitGoUpToheaven
{
    public class Util
    {
        public Util()
        {
                
        }

        public static bool Verificarfiledirectory(string path)
        {
            if (File.Exists(path))
            {
                return true;
            }else if (Directory.Exists(path))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
