    using System;
    using System.Reflection;
    using System.Windows.Forms;

    namespace WindowsFormsApplication7
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }

            private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
            {
                var assemblyName = new AssemblyName(args.Name).Name;
                if (assemblyName == "SevenZipSharp")
                {
                    using (var stream = typeof(Program).Assembly.GetManifestResourceStream(
                        "WindowsFormsApplication7." + assemblyName + ".dll"))
                    {
                        byte[] assemblyData = new byte[stream.Length];
                        stream.Read(assemblyData, 0, assemblyData.Length);
                        return Assembly.Load(assemblyData);
                    }
                }
                else
                {
                    return null;
                }
            }
        }
    }
