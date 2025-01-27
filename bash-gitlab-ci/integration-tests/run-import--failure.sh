#!/bin/bash

set -uo pipefail

source bash-gitlab-ci/util-integration-tests.sh

VAR_COMMANDS[0]="appio import -n my-app -p model.xml"
VAR_COMMANDS[1]="appio import -n my-app --path model.xml"
VAR_COMMANDS[2]="appio import --name my-app -p model.xml"
VAR_COMMANDS[3]="appio import --name --path model.xml"
VAR_COMMANDS[4]="appio import -n my-app -s"
VAR_COMMANDS[5]="appio import -n my-app --sample"
VAR_COMMANDS[6]="appio import --name my-app -s"
VAR_COMMANDS[7]="appio import --name my-app --sample"

for INDEX in "${!VAR_COMMANDS[@]}";
do
  VAR_COMMAND=${VAR_COMMANDS[INDEX]}
  
  echo "Testing command '${VAR_COMMAND}' ..."

  mkdir import--failure
  cd    import--failure

  appio new opcuaapp -n "my-app" -t "ClientServer" -u "127.0.0.1" -p "4840"
  rm --force "./appio.log"

  precondition_appio_log_file_is_not_existent
  
  ${VAR_COMMAND}
  
  check_for_non_zero_error_code
  
  check_for_exisiting_appio_log_file

  cd ..
  rm -rf import--failure

  echo "Testing command '${VAR_COMMAND}' ... done"
done