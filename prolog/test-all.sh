#!/usr/bin/env bash

set -euo pipefail

declare -i TEST_RESULT=0
FAILED_EXERCISES=''

for file in $(find * -type f -name '*.pl')
do
    exercise_dir=$(dirname "${file}")
    exercise=$(basename "${file}" .pl)
    echo "Testing ${exercise}"
    swipl -f "${exercise_dir}/${exercise}.pl" -s "${exercise_dir}/${exercise}_tests.plt" -g run_tests,halt -t 'halt(1)' -- --all
    if [ $? -ne 0 ]; then
        TEST_RESULT=1
        FAILED_EXERCISES+="${exercise}\n"
    fi
done

if [ "${TEST_RESULT}" -ne 0 ]; then
    echo "The following exercises failed"
    printf "${FAILED_EXERCISES}"
    exit "${TEST_RESULT}"
fi
