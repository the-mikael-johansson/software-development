SONAR_HOST=http://<ip>:9000

SONAR_PROJECT="myproject"
SONAR_SCANNER_ACCESS_TOKEN=""

# Starting local unzipped sonarqube manually (development/debugging)
.PHONY: start-server
start-server:
	./sonarqube-8.5.1.38104/bin/macosx-universal-64/sonar.sh console

.PHONY: begin
begin:
	dotnet sonarscanner begin /k:"$(SONAR_PROJECT)" /d:sonar.host.url="$(SONAR_HOST)" /d:sonar.login="$(SONAR_SCANNER_ACCESS_TOKEN)"

.PHONY: end
end:
	dotnet sonarscanner end /d:sonar.login="$(SONAR_SCANNER_ACCESS_TOKEN)"

.PHONY: msbuild
msbuild:
	msbuild

PHONY: msbuild-interactive
msbuild-interactive:
	msbuild  /p:NuGetInteractive=true

PHONY: restore-interactive
restore-interactive:
	dotnet restore -s "$(ARTIFACTS_ENDPOINT)" --interactive

# Default scanning
.PHONY: scan-dotnet
scan-dotnet: begin msbuild end

# Use this target when using private artifacts (nugets)
.PHONY: scan-dotnet-priv-artifacts
scan-dotnet-priv-nugets: begin restore-interactive msbuild-interactive end
