// See https://aka.ms/new-console-template for more information

using System.Reflection;
using System.Text.RegularExpressions;
using System.Text;

var sb = new StringBuilder();
sb.AppendLine("Markdown");
sb.AppendLine("- []  Test 1");
sb.AppendLine("- []  Test 2");
sb.AppendLine("- []  " + Assembly.GetExecutingAssembly().Location);

var result = sb.ToString();
Console.WriteLine(result);

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
