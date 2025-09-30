using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Utils
{
    public class HoiIdeasParser
    {
        public static string ConvertToJson(string hoi4FileContent)
        {
            var parser = new HoiIdeasParser();
            var result = parser.ParseContent(hoi4FileContent);
        
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        
            return JsonSerializer.Serialize(result, options);
        }
    
        private Dictionary<string, object> ParseContent(string content)
        {
            // Remove comments and clean up the content
            content = RemoveComments(content);
        
            // Find the main 'ideas' block
            var ideasMatch = Regex.Match(content, @"ideas\s*=\s*\{(.*)\}", RegexOptions.Singleline);
            if (!ideasMatch.Success)
                throw new ArgumentException("No 'ideas' block found in the content");
        
            var ideasContent = ideasMatch.Groups[1].Value;
            return new Dictionary<string, object>
            {
                ["ideas"] = ParseBlock(ideasContent)
            };
        }
    
        private string RemoveComments(string content)
        {
            // Remove single-line comments (# comment)
            var lines = content.Split('\n');
            var cleanedLines = new List<string>();
        
            foreach (var line in lines)
            {
                var commentIndex = line.IndexOf('#');
                if (commentIndex >= 0)
                {
                    var beforeComment = line.Substring(0, commentIndex).Trim();
                    if (!string.IsNullOrEmpty(beforeComment))
                        cleanedLines.Add(beforeComment);
                }
                else if (!string.IsNullOrWhiteSpace(line))
                {
                    cleanedLines.Add(line.Trim());
                }
            }
        
            return string.Join(" ", cleanedLines);
        }
    
        private Dictionary<string, object> ParseBlock(string content)
        {
            var result = new Dictionary<string, object>();
            var index = 0;
        
            while (index < content.Length)
            {
                // Skip whitespace
                while (index < content.Length && char.IsWhiteSpace(content[index]))
                    index++;
            
                if (index >= content.Length)
                    break;
            
                // Find the key
                var keyStart = index;
                while (index < content.Length && content[index] != '=' && content[index] != '{')
                {
                    index++;
                }
            
                var key = content.Substring(keyStart, index - keyStart).Trim();
                if (string.IsNullOrEmpty(key))
                    break;
            
                // Skip whitespace after key
                while (index < content.Length && char.IsWhiteSpace(content[index]))
                    index++;
            
                if (index >= content.Length)
                    break;
            
                // Check if we have an equals sign or direct block
                bool hasEquals = false;
                if (content[index] == '=')
                {
                    hasEquals = true;
                    index++;
                    // Skip whitespace after =
                    while (index < content.Length && char.IsWhiteSpace(content[index]))
                        index++;
                }
            
                if (index >= content.Length)
                    break;
            
                // Parse the value
                if (content[index] == '{')
                {
                    // This is a block
                    var blockContent = ExtractBlock(content, ref index);
                    result[key] = ParseBlock(blockContent);
                }
                else if (hasEquals)
                {
                    // This is a simple value
                    var value = ExtractValue(content, ref index);
                    result[key] = ParseValue(value);
                }
            }
        
            return result;
        }
    
        private string ExtractBlock(string content, ref int index)
        {
            if (content[index] != '{')
                throw new ArgumentException("Expected '{' at current position");
        
            index++; // Skip opening brace
            var braceCount = 1;
            var start = index;
        
            while (index < content.Length && braceCount > 0)
            {
                if (content[index] == '{')
                    braceCount++;
                else if (content[index] == '}')
                    braceCount--;
            
                if (braceCount > 0)
                    index++;
            }
        
            if (braceCount > 0)
                throw new ArgumentException("Unmatched opening brace");
        
            var blockContent = content.Substring(start, index - start);
            index++; // Skip closing brace
        
            return blockContent;
        }
    
        private string ExtractValue(string content, ref int index)
        {
            var start = index;
            var inQuotes = false;
        
            while (index < content.Length)
            {
                var ch = content[index];
            
                if (ch == '"')
                {
                    inQuotes = !inQuotes;
                }
                else if (!inQuotes)
                {
                    // Check for end of value (next key or block)
                    if (char.IsLetter(ch) && index > start)
                    {
                        // Look ahead to see if this might be the start of a new key
                        var remaining = content.Substring(index);
                        if (Regex.IsMatch(remaining, @"^\s*\w+\s*="))
                            break;
                    }
                
                    if (ch == '}')
                        break;
                }
            
                index++;
            }
        
            return content.Substring(start, index - start).Trim();
        }
    
        private object ParseValue(string value)
        {
            value = value.Trim();
        
            // Remove quotes if present
            if (value.StartsWith("\"") && value.EndsWith("\""))
                value = value.Substring(1, value.Length - 2);
        
            // Try to parse as number
            if (double.TryParse(value, out double doubleValue))
            {
                // Return as int if it's a whole number
                if (doubleValue == Math.Floor(doubleValue))
                    return (int)doubleValue;
                return doubleValue;
            }
        
            // Try to parse as boolean
            if (value.Equals("yes", StringComparison.OrdinalIgnoreCase))
                return true;
            if (value.Equals("no", StringComparison.OrdinalIgnoreCase))
                return false;
        
            // Return as string
            return value;
        }
    
        public static string ConvertFromJson(string jsonContent)
        {
            var parser = new HoiIdeasParser();
        
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        
            var data = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonContent, jsonOptions);
        
            var sb = new StringBuilder();
            parser.WriteHoi4Format(data, sb, 0);
        
            return sb.ToString();
        }
    
        private void WriteHoi4Format(Dictionary<string, object> data, StringBuilder sb, int indentLevel)
        {
            foreach (var kvp in data)
            {
                WriteIndent(sb, indentLevel);
            
                if (kvp.Value is JsonElement jsonElement)
                {
                    WriteKeyValue(sb, kvp.Key, jsonElement, indentLevel);
                }
                else if (kvp.Value is Dictionary<string, object> nestedDict)
                {
                    sb.AppendLine($"{kvp.Key} = {{");
                    WriteHoi4Format(nestedDict, sb, indentLevel + 1);
                    WriteIndent(sb, indentLevel);
                    sb.AppendLine("}");
                }
                else
                {
                    WriteKeyValue(sb, kvp.Key, kvp.Value, indentLevel);
                }
            }
        }
    
        private void WriteKeyValue(StringBuilder sb, string key, object value, int indentLevel)
        {
            if (value is JsonElement jsonElement)
            {
                switch (jsonElement.ValueKind)
                {
                    case JsonValueKind.Object:
                        sb.AppendLine($"{key} = {{");
                        WriteJsonObject(jsonElement, sb, indentLevel + 1);
                        WriteIndent(sb, indentLevel);
                        sb.AppendLine("}");
                        break;
                    
                    case JsonValueKind.Array:
                        // Arrays in HOI4 are typically represented as multiple key-value pairs
                        // or as space-separated values in a block
                        sb.AppendLine($"{key} = {{");
                        foreach (var item in jsonElement.EnumerateArray())
                        {
                            WriteIndent(sb, indentLevel + 1);
                            sb.AppendLine(FormatValue(item));
                        }
                        WriteIndent(sb, indentLevel);
                        sb.AppendLine("}");
                        break;
                    
                    default:
                        sb.AppendLine($"{key} = {FormatValue(jsonElement)}");
                        break;
                }
            }
            else if (value is Dictionary<string, object> dict)
            {
                sb.AppendLine($"{key} = {{");
                WriteHoi4Format(dict, sb, indentLevel + 1);
                WriteIndent(sb, indentLevel);
                sb.AppendLine("}");
            }
            else
            {
                sb.AppendLine($"{key} = {FormatValue(value)}");
            }
        }
    
        private void WriteJsonObject(JsonElement jsonElement, StringBuilder sb, int indentLevel)
        {
            foreach (var property in jsonElement.EnumerateObject())
            {
                WriteIndent(sb, indentLevel);
                WriteKeyValue(sb, property.Name, property.Value, indentLevel);
            }
        }
    
        private string FormatValue(object value)
        {
            if (value is JsonElement jsonElement)
            {
                switch (jsonElement.ValueKind)
                {
                    case JsonValueKind.String:
                        var stringValue = jsonElement.GetString();
                        // Quote strings that contain spaces or special characters
                        if (stringValue.Contains(" ") || stringValue.Contains("-") || stringValue.Contains("."))
                            return $"\"{stringValue}\"";
                        return stringValue;
                    
                    case JsonValueKind.Number:
                        if (jsonElement.TryGetInt32(out int intValue))
                            return intValue.ToString();
                        return jsonElement.GetDouble().ToString("F2").TrimEnd('0').TrimEnd('.');
                    
                    case JsonValueKind.True:
                        return "yes";
                    
                    case JsonValueKind.False:
                        return "no";
                    
                    default:
                        return jsonElement.ToString();
                }
            }
        
            return value switch
            {
                bool b => b ? "yes" : "no",
                int i => i.ToString(),
                double d => d.ToString("F2").TrimEnd('0').TrimEnd('.'),
                string s when s.Contains(" ") || s.Contains("-") || s.Contains(".") => $"\"{s}\"",
                string s => s,
                _ => value?.ToString() ?? ""
            };
        }
    
        private void WriteIndent(StringBuilder sb, int level)
        {
            for (int i = 0; i < level; i++)
            {
                sb.Append("\t");
            }
        }
    }
}