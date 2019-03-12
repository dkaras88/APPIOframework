﻿namespace Oppo.Resources.text.help
{
    public static class HelpTextValues
    {
        //General texts
        public const string GeneralUsage = "Usage:";
        public const string GeneralOptions = "Options:";
        public const string GeneralArguments = "Arguments:";

        //Help command
        public const string HelpStartWelcome = "Welcome to the Open Plug and Produce Orchestration Framework!";
        public const string HelpStartDocuLink = "For a more detailed documentation visit https://madeupwebsite.oppo/help.html";
        public const string HelpStartUsageDescription = "oppo [command] <Argument 1> <Argument n> <Options>";
        public const string HelpStartTerminology = "Terminology:";
        public const string HelpStartOpcuaapp = "opcua-app:";
        public const string HelpStartOpcuaappDescription = "and OPC UA server/client Instance generated by oppo";
        public const string HelpStartOppoOptions = "oppo-options:";
        public const string HelpStartCommand = "oppo commands";

        public const string BuildCommand = "Build an oppo project.";
        public const string PublishCommand = "Publish an oppo project for deployment.";
        public const string NewCommand = "Create a new oppo Project.";
        public const string HelpCommand = "Show command line Help.";
        public const string HelloCommand = "---";
        public const string VersionCommand = "Display the installed oppo version.";
        public const string CleanCommand = "Clean a oppo project.";
        public const string DeployStrategy = "Generate an installer containing the opcua-app.";
        public const string ImportStrategy = "Import an external ressources.";
		public const string SlnCommand = "Adds and removes opcuaapp projects from solution.";
        public const string ReferenceCommand = "Reference client adds and removes server reference from client";

		public const string HelpEndCommand = "Run \"oppo [command] --help\" for more information about a command.";

        //Build command
        public const string BuildFirstLine = "Build an oppo project.";
        public const string BuildCallDescription = "oppo build <Options>";

        //Clean command
        public const string CleanFirstLine = "Cleans an oppo project. Removes temporary files and folders.";
        public const string CleanCallDescription = "oppo clean <Options>";

        //Publish command
        public const string PublishFirstLine = "Publishes an oppo project for deployment.";
        public const string PublishCallDescription = "oppo publish <Options>";

        //Deploy command
        public const string DeployFirstLine = "Builds and installs package(.deb) containing the opcuuaapp ready for deployment.";
        public const string DeployCallDescription = "oppo deploy <Options>";

        //Import command
        public const string ImportFirstLine = "Imports an OPC UA conform information model. User specific information models needs to be placed in 'project/models'. Alternatively a sample provided by oppo can be used. Available are: DI-Informationmodel.";
        public const string ImportCallDescription = "oppo import <Arguments> <Options>";
        public const string ImportArguments = "information-model";

        //New command
        public const string NewFirstLine = "Creates a new oppo project.";
        public const string NewCallDescription = "oppo new <Arguments> <Options>";
        public const string NewArgumentsObject = "<Object> The object to create, can either be:";
        public const string NewArgumentsSln = "sln";
        public const string NewArgumentsOpcuaapp = "opcuapp";

        //Generate command
        public const string GenerateCommand = "Generates artifacts into existing oppo project.";
        public const string GenerateFirstLine = "This will update/extend an opcua-app with the chosen information model. The information model needs to be imported first by oppo 'import'.";
        public const string GenerateCallDescription = "oppo generate <Arguments> <Options>";
        public const string GenerateArguments = "information-model";
        public const string GenerateInformationModelCommandDescription = "Generates information-model code from ...";

		//Version command

		//Sln command
		public const string SlnFirstLine = "The command is used to manage projects in solution file. There are two possible arguments which allows to add and remove projects from solution.";
		public const string SlnCallDescription = "oppo sln <Arguments> <Options>";
		public const string SlnArgumentAdd = "add";
		public const string SlnArgumentBuild = "build";
		public const string SlnArgumentDeploy = "deploy";
		public const string SlnArgumentPublish = "publish";
		public const string SlnArgumentRemove = "remove";

       

		//Commands description
		public const string BuildHelpArgumentCommandDescription = "Build help";
        public const string BuildNameArgumentCommandDescription = "Project name";
        public const string CleanHelpArgumentCommandDescription = "Clean help";
        public const string CleanNameArgumentCommandDescription = "Project name";
        public const string DeployHelpArgumentCommandDescription = "Deploy help";
        public const string DeployNameArgumentCommandDescription = "Deploy name";
        public const string ImportHelpArgumentCommandDescription = "Import help";
        public const string NewHelpArgumentCommandDescription = "New help";
        public const string PublishHelpArgumentCommandDescription = "Publish help";
        public const string PublishNameArgumentCommandDescription = "Project name";
        public const string ImportSamplesArgumentCommandDescription = "Import Samples";
        public const string GenerateHelpArgumentCommandDescription = "Generate help";
        public const string SlnHelpArgumentCommandDescription = "Sln help";
        public const string SlnAddNameArgumentCommandDescription = "Add project to solution";
		public const string SlnRemoveNameArgumentCommandDescription = "Remove project from solution";
		public const string SlnBuildNameArgumentCommandDescription = "Build all solution's projects";
		public const string SlnPublishNameArgumentCommandDescription = "Publish all solution's projects";
		public const string SlnDeployNameArgumentCommandDescription = "Deploy all solution's projects";
	}
}