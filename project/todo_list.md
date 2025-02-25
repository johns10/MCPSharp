Here's a todo list for implementing the MCPSharp fork with dynamic tool registration:

# MCPSharp Fork Todo List

## Phase 1: Core Implementation
- [x] Fork the MCPSharp repository on GitHub
- [x] Clone locally and create feature branch
- [x] Make `Start()` method public in MCPServer.cs
- [x] Add static `CreateInstance()` factory method to MCPServer.cs
- [x] Create `DynamicHandlerWrapper` class
- [x] Implement `RegisterDynamicTool()` method
- [x] Implement `RegisterDynamicToolWithSchema()` method
- [x] Build to verify changes compile

## Phase 2: Testing
- [x] Create `DynamicToolTests.cs` in test project
- [x] Implement `TestDynamicToolRegistration()` test
- [x] Implement `TestDynamicToolWithSchema()` test
- [x] Run tests and fix any issues

## Phase 3: Documentation
- [x] Add XML documentation to all new methods
- [x] Update README.md with information about dynamic tool registration

## Phase 4: Finalization
- [x] Review code for style consistency
- [x] Commit changes
- [ ] Push to GitHub
- [ ] Create pull request with detailed description
- [ ] Test in our main project
