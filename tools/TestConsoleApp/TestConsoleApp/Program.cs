// See https://aka.ms/new-console-template for more information

using System.Reflection;
using System.Text.RegularExpressions;

Console.WriteLine("Hello, World!");
Console.WriteLine(Assembly.GetExecutingAssembly().Location);
//Console.WriteLine(GetCodeBaseRootPath());
//Console.WriteLine(NormalizeSearchPath("tools/test.cs"));

static string GetCodeBaseRootPath()
{
    var executionAssemblyLocation = Assembly.GetExecutingAssembly().Location;
    var appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+tools)");
    return appPathMatcher.Match(executionAssemblyLocation).Value;
}

static string NormalizeSearchPath(string path)
{
    var relativePath = NormalizeDirectoryPath(path.Replace(GetCodeBaseRootPath(), "", StringComparison.OrdinalIgnoreCase));
    return $"./{relativePath}";
}

static string NormalizeDirectoryPath(string path) => path.Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
