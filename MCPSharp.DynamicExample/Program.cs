using MCPSharp;
using MCPSharp.Model.Schemas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting Dynamic MCP Server...");
        
        // Create server instance
        var server = MCPServer.CreateInstance("DynamicServer", "1.0");
        
        // Register a simple calculator tool
        server.RegisterDynamicTool("Calculator", "Basic calculator functions", 
            new Dictionary<string, Func<Dictionary<string, object>, string>>
            {
                ["Add"] = (args) => {
                    int a = Convert.ToInt32(args["a"]);
                    int b = Convert.ToInt32(args["b"]);
                    return (a + b).ToString();
                },
                
                ["Subtract"] = (args) => {
                    int a = Convert.ToInt32(args["a"]);
                    int b = Convert.ToInt32(args["b"]);
                    return (a - b).ToString();
                }
            });
            
        // Register a tool with schema
        var stringParamSchema = new Dictionary<string, ParameterSchema>
        {
            ["text"] = new ParameterSchema { 
                Type = "string", 
                Description = "Text to process", 
                Required = true 
            }
        };
        
        server.RegisterDynamicToolWithSchema(
            "StringUtils", 
            "String utility functions",
            stringParamSchema,
            new List<string> { "text" },
            (args) => {
                string text = args["text"].ToString();
                return text.ToUpper();
            });
        
        // Start the server
        server.Start();
        
        Console.WriteLine("Server started. Press Ctrl+C to exit.");
        await Task.Delay(-1);
    }
}
