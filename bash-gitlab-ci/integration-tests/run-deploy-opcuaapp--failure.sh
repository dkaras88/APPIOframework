#!/bin/bash

set -uo pipefail

source bash-gitlab-ci/util-integration-tests.sh

VAR_COMMANDS[0]="appio deploy --name \"my/\-app\""
VAR_COMMANDS[1]="appio deploy -n     \"my/\-app\""
VAR_COMMANDS[2]="appio deploy --name"
VAR_COMMANDS[3]="appio deploy -n"
VAR_COMMANDS[4]="appio deploy --exit"
VAR_COMMANDS[5]="appio deploy -x"

for INDEX in "${!VAR_COMMANDS[@]}";
do
  VAR_COMMAND=${VAR_COMMANDS[INDEX]}
  
  echo "Testing command '${VAR_COMMAND}' ..."

  mkdir deploy--failure
  cd    deploy--failure

  precondition_appio_log_file_is_not_existent

  ${VAR_COMMAND}

  check_for_non_zero_error_code
  
  check_for_exisiting_appio_log_file

  cd ..
  rm -rf deploy--failure

  echo "Testing command '${VAR_COMMAND}' ... done"
done