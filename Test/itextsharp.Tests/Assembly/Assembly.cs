namespace itextsharp.Tests.Assembly
{
    using System;
    using System.IO;

    /// <summary>
    /// Assembly reflection helpers.
    /// </summary>
    public class Assembly
    {
        /// <summary>
        /// Gets the path of the executing assembly.
        /// <remarks><see cref="System.Reflection.Assembly.Location"/> might give inconsistent result with unit testing and running in web servers. This method aims to provide correct result.</remarks>
        /// </summary>
        public static string AssemblyPath
        {
            get
            {
                string codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                string pathUri = Uri.UnescapeDataString(uri.Path);
                string path = Path.GetDirectoryName(pathUri);

                return path;
            }
        }
    }
}
