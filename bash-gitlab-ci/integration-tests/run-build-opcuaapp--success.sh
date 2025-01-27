#!/bin/bash

set -euo pipefail

source bash-gitlab-ci/util-integration-tests.sh

VAR_COMMANDS[0]="appio build --name my-app"
VAR_COMMANDS[1]="appio build -n     my-app"

for INDEX in "${!VAR_COMMANDS[@]}";
do
  VAR_COMMAND=${VAR_COMMANDS[INDEX]}
  
  echo "Testing command '${VAR_COMMAND}' ..."

  mkdir build-opcuaapp--success
  cd    build-opcuaapp--success

  appio new opcuaapp -n "my-app" -t "ClientServer" -u "127.0.0.1" -p "4840"
  rm --force "./appio.log"

  precondition_appio_log_file_is_not_existent

  ${VAR_COMMAND}

  check_for_exisiting_file_named "./my-app/build/client-app" \
                                 "deployable client application file does not exist ..."

  check_for_executable_file "./my-app/build/client-app" \
                            "deployable client application file is not executable ..."

  check_for_exisiting_file_named "./my-app/build/server-app" \
                                 "deployable server application file does not exist ..."

  check_for_executable_file "./my-app/build/server-app" \
                            "deployable server application file is not executable ..."

  check_for_exisiting_appio_log_file

  cd ..
  rm -rf build-opcuaapp--success

  echo "Testing command '${VAR_COMMAND}' ... done"
done