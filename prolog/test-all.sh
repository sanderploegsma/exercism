#!/usr/bin/env bash

for file in **/*.pl; do
    TARGET=$(dirname $file)
    TARGET_LOWER="${TARGET/-/_}"
    swipl -f "$TARGET/$TARGET_LOWER.pl" -s "$TARGET/${TARGET_LOWER}_tests.plt" -g run_tests -t halt
done
