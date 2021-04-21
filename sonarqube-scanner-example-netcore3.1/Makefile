# Author: https://www.linkedin.com/in/the-mikael-johansson/
#
# Description: Builds, test and uploads unit test results
#              and code coverage to specified SonarQube
#              server.
#              Tested on server version: 8.6.0
#              SonarScanner for MSBuild 5.2
#              The code is build with .NET Core 3.1

SONAR_HOST=http://<YOUR IP>:9000/
SONAR_LOGIN=<YOUR TOKEN>
TEST_PROJECT=TerminalApp.Tests
TEST_RESULTS_DIR=TestResults

setup:
	dotnet tool uninstall -g dotnet-sonarscanner
	dotnet tool install --global dotnet-sonarscanner --version 5.2.0
	dotnet tool install --global dotnet-reportgenerator-globaltool --version 4.8.7

begin:
	dotnet sonarscanner begin /k:"TerminalApp" \
	/d:sonar.cs.vstest.reportsPaths="$(TEST_PROJECT)/$(TEST_RESULTS_DIR)/*.trx" \
	/d:sonar.cs.opencover.reportsPaths="$(TEST_PROJECT)\$(TEST_RESULTS_DIR)\*\coverage.opencover.xml" \
	/d:sonar.exclusions=**/*.html \
	/d:sonar.verbose=true /d:sonar.log.level="TRACE" \
	/d:sonar.host.url=$(SONAR_HOST) /d:sonar.login=$(SONAR_LOGIN) \
	/d:sonar.coverage.exclusions="**Tests*.cs"

build:
	dotnet build

clean:
	rm -rf $(TEST_PROJECT)/$(TEST_RESULTS_DIR)/ || true
	rm -rf $(TEST_PROJECT)/coverlet

test:
	dotnet test "$(TEST_PROJECT)/$(TEST_PROJECT).csproj" \
	--settings coverlet.runsettings \
	--logger trx

report:
	reportgenerator \
	-reports:$(TEST_PROJECT)/$(TEST_RESULTS_DIR)/**/coverage.cobertura.xml \
	-targetdir:report/

end:
	dotnet sonarscanner end /d:sonar.login=$(SONAR_LOGIN)

scan: clean begin build test end
