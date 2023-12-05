Task("clean")
    .Does(() => {
        DotNetClean("./src");
    });