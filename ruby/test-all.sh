#!/usr/bin/env bash

set -euo pipefail

declare -i TEST_RESULT=0
FAILED_EXERCISES=''

for file in $(find * -type f -name '*_test.rb')
do
    error=
    exercise_dir=$(dirname "${file}")
    exercise=$(basename "${file}" _test.rb)
    echo "Testing ${exercise}"
    ruby "${exercise_dir}/${exercise}_test.rb" || error=true
    if [ $error ]; then
        TEST_RESULT=1
        FAILED_EXERCISES+="${exercise}\n"
    fi
done

if [ "${TEST_RESULT}" -ne 0 ]; then
    echo "The following exercises failed:"
    echo "-------------------------------"
    printf "${FAILED_EXERCISES}"
    exit "${TEST_RESULT}"
fi