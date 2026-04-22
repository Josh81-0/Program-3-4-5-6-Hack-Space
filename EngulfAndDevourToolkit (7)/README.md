## Assignment 7 – Interactive WebAssembly Conversion

I converted the public **Blog** and **Contact** pages to use `@rendermode InteractiveWebAssembly`.  
These pages now run entirely in the browser using WebAssembly and fetch data through Web API endpoints (`/api/blog` and `/api/contact`).  

Data is loaded in `OnAfterRenderAsync` (firstRender check) to prevent double-rendering during prerender + hydration.  

Protected toolkit pages remain on Interactive Server rendering with full authentication support.

No functionality was lost — the public features are now client-side while the accounting tools stay secure on the server.