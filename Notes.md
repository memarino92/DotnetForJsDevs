# .NET for JavaScript Developers

Modern .NET is lean, fast, and more like JS than you’d probably first think. We’ll hit the history, the culture, and the strengths that make .NET worth adding to your stack. From APIs to Blazor to console apps, you’ll walk away ready to ship (and probably more hirable too). Come join us as we answer the burning question on everybody's mind: "Is C# good actually?"

## Misc

This whole repo should be clonable to follow along - this is the talk. One big markdown file and a dotnet solution file that you can spin up and start playing with right from the get-go.

## Outline

- Why .NET?
  - Jobs
  - Performance
  - Just trying new things out
  - Maybe the most controversial of all: C# is good actually
- What _is_ .NET?
  - .NET runtime in general
  - different languages (C#, F#, VB)
  - .NET Framework vs .NET Core vs .NET
  - Unity uses C# language, not really .NET. Mono runtime.
  - but in general, when people say .NET, they mean C# (just like people say JS but assume you know TS (for example I will use them almost interchangeably throughout), and F# people wouldn't pass up an opportunity to say they write F#)(how can you tell somebody's a functional programmer? Don't worry, they'll tell you.)
  - open source language, open source compiler. not all open source tooling, and some people are mad about it.
- How does it work?
  - Compiled to IL
  - Interpreted at runtime by CLR
  - Single file w/ runtime
  - AoT introduced in .NET 6
    (remember jamstack and serverless everything? show Microsoft graph from AoT doc page on resource comparison)
- Language stuff
  - Anders Heilsberg(sp?) designed both TS and C#
  - Syntax C-like, so should be familiar to JS devs
  - Things that basically look the same in both languages
    - declaring variables
    - dot syntax to access members
    - explicit typing
    - lambdas
    - spread operator and overwriting properties (vs a with b for c# records)
  - Don Syme F#, ML family of languages - very different feel - grab quote from F#FFAP site about how changing a language for the newbies confortablility of reading vs experienced programmers productivity is a bad trade
  - Nominally typed vs algebraic types, C#/TS/F#
  - Imports in TS vs using namespaces in C#
  - Other ways to use `using` (scope block, statement)
  - TS namespaces bad, C# namespaces good
  - TS enums bad, C# enums good (and `using static`)
  - Things C# has/can do that TS can't and vice versa (yes and F# too)
- Let's go already
  - Hello World
    - .NET 10 `dotnet run app.cs` without `.csproj`
  - Before .NET 10, (officially) you need a project file (XML version of `package.json`)
  - dotnet CLI
    - `dotnet new` and `dotnet new list`
  - First cultural difference: Sln vs monorepo
  - Sln is standard for containing multiple projects, where projects can reference and depend on each other (very common)
  - Monorepos relatively new thing in TS land comparatively
  - In addition to references to other projects, project files contain packages from a registry (Nuget vs npm)
  - Create slns and projects from templates, link projects together, add packages, restore packages, build, run, watch (hot reload), publish, run tests are things I do daily using cli
- Web development
  - ASP.NET SDK, brief history (it's been around a long time)
  - Controllers in repsonse to Ruby on Rails and that stuck around a long time. MVC pattern very popular.
  - Minimal APIs
    - manual route registration, no reflection based controller setup. Perfect for AoT
    - less "magic", easier to learn, faster to get up and running
    - Link blog on organizing Minimal Apis
  - Configuration loading for multiple environments built in
    - secrets manager for Dev
  - Service Container and dependancy injection
    - Singleton, Scoped and Transient
    - Constructor injection
    - Can use this same system with `ApplicationBuilder` in a console app
  - Logging with ILogger<T>
    - Scoped logging
    - Structured logging
  - Blazor
    - Microsoft's answer to Component driven UIs
    - .`razor` and `.cshtml` templating syntax been around for a while now in MVC, but a `PartialView` is not the same as a named, reusable and composable Component.
    - Two modes of interactivity, as well as purely server-rendered.
    - Web Assembly
      - A SPA that ships what you can think of as two web assembly bundles to the browser - the .NET runtime itself and you app to run on top of it. Thin JS layer to do DOM manipulation.
    - Interactive Server
      - Opens Websocket connection to client. Degrades gracefully to server-sent events and long polling where the server will just hang onto the request until it either times out or has something to send back. JS responsible for passing events back over the wire, and applying DOM updates that come in from the server
      - Application runs in-memory on the server. Hard navigtions or refresh break the Websocket connection and all ephemeral state is lost.
    - Tailwind works great (duh). Can put build command in project file. Watch from tailwind cli plays great with hot reload from dotnet watch.
- Other .NET stuff out there
  - .NET.ML
  - Orleans virtual actor model (powers Halo backend)
  - .NET MAUI, run blazor in mobile apps
