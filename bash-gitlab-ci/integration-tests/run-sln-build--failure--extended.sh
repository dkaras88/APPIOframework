#!/bin/bash

set -uo pipefail

source bash-gitlab-ci/util-integration-tests.sh

VAR_COMMANDS[0]="appio sln build -s solutionName"
VAR_COMMANDS[1]="appio sln build --solution solutionName"

echo "Testing failure of package preparation ..."

for INDEX in "${!VAR_COMMANDS[@]}";
do
  VAR_COMMAND=${VAR_COMMANDS[INDEX]}
  
  echo "Testing command '${VAR_COMMAND}' ..."

  mkdir sln-build--failure--extended
  cd    sln-build--failure--extended

  appio new opcuaapp --name "my-app" -t "ClientServer" -u "127.0.0.1" -p "4840"
  appio new sln --name "testSln"
  rm --force "./testSln.sln"
  rm --force "./appio.log"

  precondition_appio_log_file_is_not_existent

  ${VAR_COMMAND}

  check_for_non_zero_error_code
  
  check_for_exisiting_appio_log_file

  cd ..
  rm -rf sln-build--failure--extended

  echo "Testing command '${VAR_COMMAND}' ... done"
done