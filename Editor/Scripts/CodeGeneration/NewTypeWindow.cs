using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

public class NewTypeWindow : EditorWindow
{

  // 0 -> types uppercase, separated by "-"
  // 1 -> types uppercase, joined
  // 2 -> types original case, separated by ", "
  // 3 -> number of generic parent class name (ex: Two for TwoTypeGameEvent)
  const string gameEventTemplate = "using UnityEngine;\n\n" +
"namespace FredericRP.EventManagement\n" +
"{\n" +
  "  [CreateAssetMenu(menuName = \"FredericRP/<0> Game Event\")]\n" +
  "  public class <1>GameEvent : <3>TypeGameEvent<<2>>\n" +
  "  { }\n" +
"}";

  // 0 -> types uppercase, joined
  // 1 -> number of generic parent class name (ex: Two for TwoTypeGameEvent)
  // 2 -> types original case, separated by ", "
  const string inspectorTemplate = "using UnityEditor;\n\n" +
"namespace FredericRP.EventManagement\n" +
"{\n" +
  "  [CustomEditor(typeof(<0>GameEvent))]\n" +
  "  public class <0>GameEventInspector : <1>TypeGameEventInspector<<2>>\n" +
  "  { }\n" +
"}";

  string[] NumberAsWord = new string[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten" };

  [MenuItem("Window/FredericRP/EventManagement/New type generation")]
  public static void DisplayWindow()
  {
    NewTypeWindow window = EditorWindow.CreateWindow<NewTypeWindow>("New typed game event");
    window.Show();
    window.Focus();
  }

  int typeCount = 2;
  List<string> typeList = new List<string>();

  private void OnGUI()
  {
    // type count
    typeCount = (int)EditorGUILayout.Slider("Type count", typeCount, 1, 10);
    bool enableButton = true;
    // list of types
    for (int i = 0; i < typeCount; i++)
    {
      if (typeList.Count < i + 1)
        typeList.Add("");
      typeList[i] = EditorGUILayout.TextField(string.Format("Type #{0} name", i), typeList[i]);
      Type typeCheck = GetTypeFromAliasOrName(typeList[i]);
      if (typeCheck == null)
      {
        EditorGUILayout.HelpBox("This type has not been found", MessageType.Warning);
      }
      else if (typeCheck.IsGenericType)
      {
        enableButton = false;
        EditorGUILayout.HelpBox("Generic types are not supported, that's the whole purpose", MessageType.Error);
      }
    }
    // generate !
    bool wasEnabled = GUI.enabled;
    GUI.enabled = enableButton;
    if (GUILayout.Button("Generate"))
    {
      Generate();
    }
    GUI.enabled = wasEnabled;
  }

  void Generate()
  {
    // Trim types after type count
    typeList.RemoveRange(typeCount, typeList.Count - typeCount);
    List<string> cleanedTypeList = new List<string>();
    cleanedTypeList.AddRange(typeList);
    List<string> uppercaseTypeList = new List<string>();
    string constructedType = "";
    uppercaseTypeList.Clear();

    for (int i = 0; i < typeCount; i++)
    {
      uppercaseTypeList.Add("");
      cleanedTypeList[i] = cleanedTypeList[i].Replace("<", "").Replace(">", "").Replace("[", "").Replace("]", "");
      uppercaseTypeList[i] = cleanedTypeList[i][0].ToString().ToUpper() + cleanedTypeList[i].Substring(1);
      // Add uppercase type to the full name, without list or array characters
      constructedType += uppercaseTypeList[i];
    }
    constructedType += "GameEvent";
    string gameEventFixedTemplate = FixTemplate(gameEventTemplate);
    string inspectorFixedTemplate = FixTemplate(inspectorTemplate);
    // Check if type exists
    Type type = Type.GetType(constructedType);
    if (type != null)
    {
      Debug.LogError("This type already exists, will not generate.");
      return;
    }
    // if not, create typed game event and inspector

    // 0 -> types uppercase, separated by "-"
    // 1 -> types uppercase, joined
    // 2 -> types original case, separated by ", "
    // 3 -> number of generic parent class name (ex: Two for TwoTypeGameEvent)
    string gameEventClass = string.Format(gameEventFixedTemplate, string.Join("-", uppercaseTypeList), string.Join("", uppercaseTypeList), string.Join(", ", typeList), NumberAsWord[typeCount - 1]);
    //Debug.Log("Generated class:");
    //Debug.Log(gameEventClass);
    // 0 -> types uppercase, joined
    // 1 -> number of generic parent class name (ex: Two for TwoTypeGameEvent)
    // 2 -> types original case, separated by ", "
    string inspectorEventClass = string.Format(inspectorFixedTemplate, string.Join("", uppercaseTypeList), NumberAsWord[typeCount - 1], string.Join(", ", typeList));
    //Debug.Log("Generated inspector class:");
    //Debug.Log(inspectorEventClass);
    // Build output path
    string currentPath = AssetDatabase.GetAssetPath(MonoScript.FromScriptableObject(this));
    DirectoryInfo firstParent = Directory.GetParent(Directory.GetParent(Application.dataPath).FullName + "/" + currentPath).Parent;
    string editorPath = firstParent.FullName + "/Typed/" + constructedType + "Inspector.cs";
    string runtimePath = firstParent.Parent.Parent + "/Runtime/Scripts/TypedGameEvent/Typed/" + constructedType + ".cs";
    //Debug.Log("Will output game event here: " + runtimePath);
    //Debug.Log("Will output inspector here: " + editorPath);
    // Write as files
    WriteFile(runtimePath, gameEventClass);
    WriteFile(editorPath, inspectorEventClass);
    AssetDatabase.Refresh();
    Debug.Log("New " + constructedType + " type created");
    // 
    /*
    var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
    for (int i = 0; i < loadedAssemblies.Length; i++)
    {
      Debug.Log("Assembly#" + i + ": " + loadedAssemblies[i].FullName);
    }
    // */
  }

  string FixTemplate(string input)
  {
    string result = input.Replace("{", "{{").Replace("}", "}}");
    return Regex.Replace(result, "(<)(.)(>)", "{$2}");
  }

  void WriteFile(string filePath, string content)
  {
    FileInfo fi = new FileInfo(filePath);
    // Get parent, then add Resources/datafile/pds-specific-class.txt to get the correct data path
    string dataDirectory = fi.Directory.FullName;
    // ensure directory exists
    if (!File.Exists(dataDirectory))
      Directory.CreateDirectory(dataDirectory);

    using (FileStream fs = File.Create(filePath))
    {
      StreamWriter writer = new StreamWriter(fs);


      writer.Write(content);

      writer.Close();
      fs.Close();
    }
  }

  #region type check
  static Dictionary<string, Type> _typeAlias = new Dictionary<string, Type>
{
    { "bool", typeof(bool)},
    { "byte", typeof(byte) },
    { "char", typeof(char) },
    { "decimal", typeof(decimal) },
    { "double", typeof(double) },
    { "float", typeof(float) },
    { "int", typeof(int) },
    { "long", typeof(long) },
    { "object", typeof(object) },
    { "sbyte", typeof(sbyte) },
    { "short", typeof(short) },
    { "string" , typeof(string)},
    { "uint", typeof(uint) },
    { "ulong", typeof(ulong) },
    // Yes, this is an odd one.  Technically it's a type though.
    { "void", typeof(void) }
};

  static Type GetTypeFromAliasOrName(string typeName)
  {
    Type type;
    // Lookup alias for type
    if (_typeAlias.TryGetValue(typeName, out type))
      return type;

    // Try global load
    type = Type.GetType(typeName);
    if (type == null)
    {
      // If not found, try default assembly one
      type = TryLoadType("Assembly-CSharp", typeName);
      if (type == null)
      {
        // If not found, try to find automatically the assembly from package name
        int length = typeName.LastIndexOf('.');
        if (length > 0)
        {
          string assemblyName = typeName.Substring(0, length);
          // Use qualified name to retrieve assembly name and load it
          type = TryLoadType(assemblyName, typeName);
          // but with unity packages, it can fail to load it, try "sub" assemblies instead: Runtime and Editor
          if (type == null)
            type = TryLoadType(assemblyName + ".Runtime", typeName);
          if (type == null)
            type = TryLoadType(assemblyName + ".Editor", typeName);
        }
      }
    }
    return type;
  }

  /// <summary>
  /// Try to load a type from assembly and a type names
  /// </summary>
  /// <param name="assemblyName"></param>
  /// <param name="typeName"></param>
  /// <returns>the type if found, null otherwise</returns>
  protected static Type TryLoadType(string assemblyName, string typeName)
  {
    try
    {
      Assembly requiredAssembly = Assembly.Load(assemblyName);
      return requiredAssembly?.GetType(typeName);
    }
    catch (Exception) { }
    return null;
  }
  #endregion
}
