# .NET Web Development

### Project has been created based on *Full Stack .NET Web Development* by Piotr Gankiewicz

### Code Style Rules and Formatter
Formatter for this project: [dotnet-format](https://github.com/dotnet/format)
```
dotnet tool install -g dotnet-format
```
All rules are inherited from official configuration from Microsoft DOCS except of shown below.
In order to change them edit `.editorconfig` file and run `dotnet-format` 
```
root = true
[*.cs]

insert_final_newline = true
max_line_length=100

csharp_new_line_before_catch = false
csharp_new_line_before_else = false
csharp_new_line_before_finally = false
csharp_new_line_before_members_in_anonymous_types = false
csharp_new_line_before_members_in_object_initializers = false
csharp_new_line_before_open_brace = none
csharp_new_line_between_query_expression_clauses = true
```
