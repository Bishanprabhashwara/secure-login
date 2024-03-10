using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public interface SecuritySystem
    {
        void VerifySecurity();
    }
    public class password : SecuritySystem
    {
        void SecuritySystem.VerifySecurity()
        {
            Form1 pass = new Form1();
            pass.Show();
        }
    }
    public class facereg : SecuritySystem
    {
        void SecuritySystem.VerifySecurity()
        {
            Form3 face = new Form3(1);
            face.Show();
            face.capt();
        }
    }
    public class SecurityFactory
    {
        SecuritySystem secSystem;
        public static SecuritySystem verify(string ver)
        {
            if (ver.Equals("1"))
            {
                return new password();
            }
            if(ver.Equals("2"))
            {
                return new facereg();
            }

            return null;
        }
    }
    public class Class1
    {
        
        public void chose(string ver)
        {
            SecuritySystem sys = SecurityFactory.verify(ver);
            sys.VerifySecurity();

        }     

    }
}
