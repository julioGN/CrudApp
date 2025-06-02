For my backend on macOS, I needed SQL Server in Docker since Windows‑style connection strings failed. 
I ran a Docker container with an updated UseSqlServer(...) in Program.cs. 
Finally, I created a .vscode/launch.json and tasks.json so I could build the solution and run both API and Blazor projects together. 
Now my code navigates correctly, handles IDs consistently, displays full client names, and both applications launch smoothly in VS Code.

Focused on making Create, Read, Update, and Delete flows work seamlessly. 
For Create, I configured form submission so new client records post correctly to the API. 
For Read, I implemented Http.GetFromJsonAsync<List<Client>> in my index page to fetch and display the full client list, ensuring IDs and names appear properly. 
For Update, I introduced an intermediate int IdInt so Blazor binds route parameters while my model still uses short Id, then send a PutAsJsonAsync back to the API. 
For Delete, I updated the confirmation page to fetch the client name and call http.DeleteAsync($"…/Clients/{Id}").

Deployed tools such as Docker, Postman, Blazor WASM, .NET Core, SQL, JSON, HTML, and CSS.
