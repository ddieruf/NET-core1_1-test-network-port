###Refer to the SampleText.txt file to see a sample HTTP POST. 

Inside the dotnet-core-test-port folder, you will find a manifest.yml. This is the configuration that will be pushed to PCF. Run cf push from this directory. Then using your favorite web debugger tool, execute a POST to the url of the pushed app, providing the settings in the request body.