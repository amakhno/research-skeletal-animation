using System;
using OpenTK;

namespace Graphics
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            using(Viewer viewer = new Viewer())
            {
                var obj = new WorldObject("Bob");
                viewer.Objects.Add(obj);
                viewer.FocusObject = obj;

                viewer.Run(165.0);
            }
        }
    }
}