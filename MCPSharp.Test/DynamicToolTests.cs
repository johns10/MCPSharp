using MCPSharp.Model.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCPSharp.Test
{
    [TestClass]
    public class DynamicToolTests
    {
        [TestMethod]
        public async Task TestDynamicToolRegistration()
        {
            // Create server instance
            var server = MCPServer.CreateInstance("TestServer", "1.0");
            
            // Register a dynamic tool
            server.RegisterDynamicTool("Calculator", "Test calculator", 
                new Dictionary<string, Func<Dictionary<string, object>, string>>
                {
                    ["Add"] = (args) => {
                        int a = Convert.ToInt32(args["a"]);
                        int b = Convert.ToInt32(args["b"]);
                        return (a + b).ToString();
                    }
                });
                
            // Get tool listing
            var result = await server.ListToolsAsync();
            
            // Verify the tool is registered
            Assert.IsTrue(result.Tools.Any(t => t.Name == "Add"));
            Assert.AreEqual("Test calculator", result.Tools.First(t => t.Name == "Add").Description);
        }
        
        [TestMethod]
        public async Task TestDynamicToolWithSchema()
        {
            var server = MCPServer.CreateInstance("TestServer", "1.0");
            
            var parameterSchemas = new Dictionary<string, ParameterSchema>
            {
                ["a"] = new ParameterSchema { 
                    Type = "number", 
                    Description = "First number", 
                    Required = true 
                },
                ["b"] = new ParameterSchema { 
                    Type = "number", 
                    Description = "Second number", 
                    Required = true 
                }
            };
            
            server.RegisterDynamicToolWithSchema(
                "Multiply", 
                "Multiplication function",
                parameterSchemas,
                new List<string> { "a", "b" },
                (args) => {
                    int a = Convert.ToInt32(args["a"]);
                    int b = Convert.ToInt32(args["b"]);
                    return (a * b).ToString();
                });
                
            var result = await server.ListToolsAsync();
            
            var tool = result.Tools.First(t => t.Name == "Multiply");
            Assert.AreEqual("Multiplication function", tool.Description);
            Assert.AreEqual(2, tool.InputSchema.Properties.Count);
            Assert.AreEqual("number", tool.InputSchema.Properties["a"].Type);
            Assert.AreEqual(2, tool.InputSchema.Required.Count);
        }
    }
}
