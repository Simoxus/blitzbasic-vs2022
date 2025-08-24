# BlitzBasic Language Support for VS 2022

An extension for Visual Studio 2022 that gives simple support for the BlitzBasic programming language. It currently features **only** syntax highlighting, however it will eventually feature a basic form of autocompletion.

## Contact

Please send a direct message over to me on Discord (@Simoxus) if you have any suggestions, or encounter any bugs. Thank you >3

## For Developers

### Installing the correct modules

In order to compile BlitzBasicLanguageSupport, you'll need to make sure you have the "**Visual Studio extension development**" and "**.NET desktop development**" modules installed.

### Modifying the syntax highlighting logic

Once you've opened the solution ("**BlitzBasicLanguageSupport.sln**"), you will need to modify the files below to add new syntax:
* ```BlitzBasicClassifier.cs```
* ```BlitzBasicFormats.cs```
* ```BlitzBasicTypes.cs```

The scripts above are really bad practice, and I wouldn't recommend it. They will be refactored eventually :joy:
