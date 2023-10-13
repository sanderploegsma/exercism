#!/usr/bin/env bash

set -euo pipefail

trap "exit 1" SIGINT SIGTERM

declare -i TEST_RESULT=0
FAILED_EXERCISES=''

function print_block {
    printf "\n\n"
    printf '=%.0s' {1..80}
    printf "\n$1\n"
    printf '=%.0s' {1..80}
    printf "\n\n"
}

for file in $(find . -type f -name 'mix.exs')
do
    error=
    exercise_dir=$(dirname "${file}")
    exercise=${exercise_dir#./}
    
    print_block "${exercise}"

    cd "${exercise_dir}"
    mix test || error=true
    if [ $error ]; then
        TEST_RESULT=1
        FAILED_EXERCISES+="${exercise}\n"
    fi
    cd ..
done

if [ "${TEST_RESULT}" -ne 0 ]; then
    print_block "The following exercises failed"
    printf "${FAILED_EXERCISES}"
    exit "${TEST_RESULT}"
fi
