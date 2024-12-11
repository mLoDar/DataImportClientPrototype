# DesktopClientPrototype

## Reference
This repository serves as prototype for this [project](https://github.com/mLoDar/DataImportClient)

This repository aims to do the following things:
- Show a potential design for the finished project
- Show the potential naviagation and overall usage for the finished project

## Other services used
- This [website](https://patorjk.com/software/taag/#p=display&f=Tmplr) was used for creating headers within the application.

## Notes for the application

### Error logging
There should be **two** types of error logging
1. Logging to a local file
2. Having a temporary error cache
   
```(This should include the last 50-100 errors cached inside a List<string>)```

Why this system?

If there is an error with writing to the error file, the application should have saved the reason somewhere.

That should be the entire purpose of this temporary error cache
